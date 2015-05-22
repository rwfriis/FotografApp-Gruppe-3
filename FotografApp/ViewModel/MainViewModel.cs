using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FotografApp.Common;
using FotografApp.Handler;
using FotografApp.Model;
using FotografApp.View;

namespace FotografApp.ViewModel
{
    class MainViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Tlf { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        private ICommand _createUserCommand;
        public Handler.OrderHandler OrderHandler { get; set; }
        public Handler.UserHandler UserHandler { get; set; }


        public MainViewModel()
        {
            OrderHandler = new OrderHandler(this);
            UserHandler = new UserHandler(this);
        }

        public ICommand CreateUserCommand
        {
            get { return _createUserCommand ?? (_createUserCommand = new RelayCommand(UserHandler.CreateUser)); }
            set { _createUserCommand = value; }
        }
    }
}
