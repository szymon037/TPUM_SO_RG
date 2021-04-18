using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;

using Logic.DataDTO;
using Logic.Systems;
using Logic;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            UserSystem = new UserSystem();
            BookSystem = new BookSystem();
            OrderSystem = new OrderSystem();

            Users = new ObservableCollection<UserDTO>(UserSystem.GetUsers());
            Books = new ObservableCollection<BookDTO>(BookSystem.GetAvailableBooks());

            AddUserCommand = new AddUserCommand(AddUser);
            AddBookCommand = new AddBookCommand(AddBook);
            ClosePopupCommand = new ClosePopupCommand(ClosePopup);
            ReturnBookCommand = new ReturnBookCommand(ReturnBook);
            BorrowBookCommand = new BorrowBookCommand(BorrowBook);

            ReactiveMessageShow = false;
            MessageContent = "Gen";

            _ReactiveTimer = new ReactiveTimer(TimeSpan.FromSeconds(10));
            _TickObservable = Observable.FromEventPattern<ReactiveEvent>(_ReactiveTimer, "Tick");
            _Observer = _TickObservable.Subscribe(x => ReactiveMessageShow = true);
            _ReactiveTimer.Start();
        }

        public void AddUser(string userName)
        {
            if (userName == null)
                return;

            var res = UserSystem.AddUser(new UserDTO { Name = userName, Address = "" });
            if (res is null) return;
            Users.Add(res);
        }

        public void AddBook(string bookTitle)
        {
            if (bookTitle == null)
                return;

            var res = BookSystem.AddBook(new BookDTO { Title = bookTitle, Author = "" });
            if (res is null) return;
            Books.Add(res);
            MessageContent = "";
        }

        public void ReturnBook()
        {
            if (SelectedOrder == null || SelectedOrder.Returned)
                return;

            BookDTO book = OrderSystem.ReturnBook(SelectedOrder);
            if (book is null) return;
            Books.Add(book);
            OrderedBooks = new ObservableCollection<OrderDTO>(OrderSystem.GetUserOrders(_SelectedUser.ID));
        }

        public void BorrowBook()
        {
            if (SelectedBook == null || SelectedUser == null)
                return;

            OrderDTO order = OrderSystem.BorrowBook(SelectedBook, SelectedUser);
            if (order is null) return;
            Books.Remove(SelectedBook);
            OrderedBooks.Add(order);
        }

        public void ClosePopup()
        {
            ReactiveMessageShow = false;
        }

        public ObservableCollection<UserDTO> Users
        {
            get => _Users;
            set
            {
                _Users = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<BookDTO> Books
        {
            get => _Books;
            set
            {
                _Books = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OrderDTO> OrderedBooks
        {
            get => _OrderedBooks;
            set
            {
                _OrderedBooks = value;
                MessageContent = "";
                RaisePropertyChanged();
            }
        }

        public BookDTO SelectedBook
        {
            get => _SelectedBook;
            set
            {
                _SelectedBook = value;
                RaisePropertyChanged();
            }
        }

        public OrderDTO SelectedOrder
        {
            get => _SelectedOrder;
            set
            {
                _SelectedOrder = value;
                RaisePropertyChanged();
            }
        }

        public UserDTO SelectedUser
        {
            get => _SelectedUser;
            set
            {
                _SelectedUser = value;
                RaisePropertyChanged();

                OrderedBooks = new ObservableCollection<OrderDTO>(OrderSystem.GetUserOrders(_SelectedUser.ID));
            }
        }

        public bool ReactiveMessageShow
        {
            get => _ReactiveMessageShow;
            set
            {
                _ReactiveMessageShow = value;
                RaisePropertyChanged();
            }
        }

        public string MessageContent
        {
            get => _MessageContent;
            private set
            {
                _MessageContent = "In our library you can find over " + (BookSystem.GetNumberOfBooks() - 1).ToString() + " books!";
                RaisePropertyChanged();
            }
        }

        public AddUserCommand AddUserCommand { get; private set; }
        public AddBookCommand AddBookCommand { get; private set; }
        public ClosePopupCommand ClosePopupCommand { get; private set; }
        public ReturnBookCommand ReturnBookCommand { get; private set; }
        public BorrowBookCommand BorrowBookCommand { get; private set; }

        private IUserSystem UserSystem;
        private IOrderSystem OrderSystem;
        private IBookSystem BookSystem;

        private ObservableCollection<UserDTO> _Users;
        private ObservableCollection<BookDTO> _Books;
        private ObservableCollection<OrderDTO> _OrderedBooks;

        private BookDTO _SelectedBook;
        private OrderDTO _SelectedOrder;
        private UserDTO _SelectedUser;

        private ReactiveTimer _ReactiveTimer;
        private IObservable<EventPattern<ReactiveEvent>> _TickObservable;
        private IDisposable _Observer; 

        private bool _ReactiveMessageShow;
        private string _MessageContent;
    }
}
