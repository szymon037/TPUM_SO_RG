using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Model.Repository;
using Model.Data;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            NewUser = new User();
            NewBook = new Book();
            SelectedBook = null;
            SelectedUser = null;
            ResultText = "Test";
            Database = new Database();
            //FetchDataCommand = new RelayCommand(Database = new Database());
            AddUserCommand = new AddUserCommand(AddUser);//new RelayCommand(() => Users.Add(new User { ID = Guid.NewGuid().ToString(), Name = UserNameText, Surname = UserSurnameNameText, Address = "AAA" }));
            AddBookCommand = new AddBookCommand(AddBook);//new RelayCommand(() => Users.Add(new User { ID = Guid.NewGuid().ToString(), Name = UserNameText, Surname = UserSurnameNameText, Address = "AAA" }));
        }

        public void AddUser(User user)
        {
            if (user.Name == null || user.Surname == null)
                return;

            Users.Add(new User { ID = Guid.NewGuid().ToString(), Name = user.Name, Surname = user.Surname, Address = user.Address });
            NewUser = new User();
        }

        public void AddBook(Book book)
        {
            if (book.Title == null || book.Author == null)
                return;

            Books.Add(new Book { ID = Guid.NewGuid().ToString(), Title = book.Title, Author = book.Author });
            NewBook = new Book();
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
            }
        }

        public User NewUser
        {
            get => _NewUser;
            set
            {
                _NewUser = value;
                RaisePropertyChanged();
            }
        }

        public Book NewBook
        {
            get => _NewBook;
            set
            {
                _NewBook = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand FetchDataCommand
        {
            get; private set;
        }

        public AddUserCommand AddUserCommand
        {
            get; private set;
        }

        public AddBookCommand AddBookCommand
        {
            get; private set;
        }

        private Database _Database;
        private ObservableCollection<User> _Users;
        private ObservableCollection<Book> _Books;
        private Book _SelectedBook;
        private User _SelectedUser;
        private User _NewUser;
        private Book _NewBook;
        public string ResultText { get; set; }
    }
}
