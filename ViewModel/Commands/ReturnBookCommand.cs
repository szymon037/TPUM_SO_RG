using System;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;
using Logic;

namespace ViewModel.Commands
{
    public class ReturnBookCommand : RelayCommand
    {
        public ReturnBookCommand(Action execute)
        {
            ReturnBook = execute;
        }

        public override void Execute(object parameter)
        {
            ReturnBook();
        }

        public Action ReturnBook;
    }
}
