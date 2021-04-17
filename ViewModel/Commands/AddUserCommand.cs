using Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Commands
{
    public class AddUserCommand : RelayCommand
    {
        public AddUserCommand(Action<User> execute)
        {
            AddUser = execute;
        }

        public override void Execute(object parameter)
        {
            AddUser((User)parameter);
        }

        public Action<User> AddUser;
    }
}
