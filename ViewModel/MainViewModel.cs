using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Reactive;
using System.Reactive.Linq;

using Model.Repository;
using Model.Data;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            SelectedBook = null;
            SelectedUser = null;
            Database = new Database();

            AddUserCommand = new AddUserCommand(AddUser);
            AddBookCommand = new AddBookCommand(AddBook);
            ClosePopupCommand = new ClosePopupCommand(ClosePopup);

            ReactiveMessageShow = true;
            MessageContent = "";

            _ReactiveTimer = new ReactiveTimer(TimeSpan.FromSeconds(10));
            _TickObservable = Observable.FromEventPattern<ReactiveEvent>(_ReactiveTimer, "Tick");
            _Observer = _TickObservable.Subscribe(x => ReactiveMessageShow = true);
            _ReactiveTimer.Start();
        }

        public void AddUser(string userName)
        {
            if (userName == null)
                return;

            Users.Add(new User { ID = Guid.NewGuid().ToString(), Name = userName, Address = "" });
        }

        public void AddBook(string bookTitle)
        {
            if (bookTitle == null)
                return;

            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = bookTitle, Author = "" });
        }

        public void ClosePopup()
        {
            ReactiveMessageShow = false;
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Book> Books
        {
            get
            {
                return _Books;
            }
            set
            {
                _Books = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Book> OrderedBooks
        {
            get
            {
                return _OrderedBooks;
            }
            set
            {
                _OrderedBooks = value;
                MessageContent = "";
                RaisePropertyChanged();
            }
        }

        public Database Database
        {
            get => _Database;
            set
            {
                _Database = value;
                Users = new ObservableCollection<User>(value.Users);
                Books = new ObservableCollection<Book>(value.Books);
            }
        }

        public Book SelectedBook
        {
            get => _SelectedBook;
            set
            {
                _SelectedBook = value;
                RaisePropertyChanged();
            }
        }

        public User SelectedUser
        {
            get => _SelectedUser;
            set
            {
                _SelectedUser = value;
                RaisePropertyChanged();
                if (_SelectedUser == null)
                    return;
                List<Order> orderList = Database.Orders.FindAll(o => o.UserID == SelectedUser.ID);
                ObservableCollection<Book> orderedBooks = new ObservableCollection<Book>();

                for (int i = 0; i < orderList.Count; i++)
                    orderedBooks.Add(Database.Books.Find(b => b.ID == orderList[i].BookID));

                OrderedBooks = orderedBooks;
            }
        }

        public bool ReactiveMessageShow
        {
            get
            {
                return _ReactiveMessageShow;
            }
            set
            {
                _ReactiveMessageShow = value;
                RaisePropertyChanged();
            }
        }

        public string MessageContent
        {
            get
            {
                return _MessageContent;
            }
            private set
            {
                _MessageContent = "In our library you can find over " + (_Books.Count - 1).ToString() + " books!";
                RaisePropertyChanged();
            }
        }

        public AddUserCommand AddUserCommand
        {
            get; private set;
        }

        public AddBookCommand AddBookCommand
        {
            get; private set;
        }

        public ClosePopupCommand ClosePopupCommand
        {
            get; private set;
        }

        private Database _Database;
        private ObservableCollection<User> _Users;
        private ObservableCollection<Book> _Books;
        private ObservableCollection<Book> _OrderedBooks;
        private Book _SelectedBook;
        private User _SelectedUser;

        private ReactiveTimer _ReactiveTimer;
        private IObservable<EventPattern<ReactiveEvent>> _TickObservable;
        private IDisposable _Observer; 

        private bool _ReactiveMessageShow;
        private string _MessageContent;
    }
}
