using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Model.Repository;
using Model.Data;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            SelectedBook = null;
            SelectedUser = null;
            ResultText = "Test";

            FetchDataCommand = new RelayCommand(() => Database = new Database());
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

        public RelayCommand FetchDataCommand
        {
            get; private set;
        }

        private Database _Database;
        private ObservableCollection<User> _Users;
        private ObservableCollection<Book> _Books;
        private Book _SelectedBook;
        private User _SelectedUser;
        public string ResultText { get; set; }
    }
}
