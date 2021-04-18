using System;
using System.Collections.Generic;
using System.Text;

using Logic.DataDTO;
using Logic;

namespace ViewModel.Commands
{
    public class BorrowBookCommand : RelayCommand
    {
        public BorrowBookCommand(Action execute)
        {
            BorrowBook = execute;
        }

        public override void Execute(object parameter)
        {
            BorrowBook();
        }

        public Action BorrowBook;
    }
}
