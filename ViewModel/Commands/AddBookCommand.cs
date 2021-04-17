using Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Commands
{
    public class AddBookCommand : RelayCommand
    {
        public AddBookCommand(Action<Book> execute)
        {
            AddBook = execute;
        }

        public override void Execute(object parameter)
        {
            AddBook((Book)parameter);
        }

        public Action<Book> AddBook;
    }
}
