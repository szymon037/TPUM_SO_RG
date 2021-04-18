using System;

namespace ViewModel.Commands
{
    public class AddUserCommand : RelayCommand
    {
        public AddUserCommand(Action<string> execute)
        {
            AddUser = execute;
        }

        public override void Execute(object parameter)
        {
            AddUser((string)parameter);
        }

        public Action<string> AddUser;
    }
}
