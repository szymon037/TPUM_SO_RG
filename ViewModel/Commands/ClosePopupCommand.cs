using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Commands
{
    public class ClosePopupCommand : RelayCommand
    {
        public ClosePopupCommand(Action execute)
        {
            ClosePopup = execute;
        }

        public override void Execute(object parameter)
        {
            ClosePopup();
        }

        public Action ClosePopup;
    }
}
