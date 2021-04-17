using Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Commands
{
    public class AddBookCommand : RelayCommand
    {
        public AddBookCommand(Action<string> execute)
        {
            AddBook = execute;
        }

        public override void Execute(object parameter)
        {
            AddBook((string)parameter);
        }

        public Action<string> AddBook;
    }
}
