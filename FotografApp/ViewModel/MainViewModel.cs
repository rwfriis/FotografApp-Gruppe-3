using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FotografApp.ViewModel
{
    class MainViewModel
    {
        private ICommand _createUserCommand;
        public Handler.OrderHandler OrderHandler { get; set; }
        public Handler.UserHandler UserHandler { get; set; }


        public MainViewModel()
        {
        }

        public ICommand CreatUserCommand
        {
            get { return _createUserCommand ?? (_createUserCommand = new RelayCommand(UserHandler.CreateUser())); }
            set { _createUserCommand = value; }
        }
    }
}
