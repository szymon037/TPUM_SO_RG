using System;
using System.Windows.Input;

namespace ViewModel
{
    public abstract class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public abstract void Execute(object parameter);


    }
}
