using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FotografApp.Annotations;
using FotografApp.Common;
using FotografApp.Handler;

namespace FotografApp.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _createUserCommand;
        private ICommand _loginCommand;
        private string _email = "Email";
        private string _password = "Password";
        public OrderHandler OrderHandler { get; set; }
        public UserHandler UserHandler { get; set; }

        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        public MainViewModel()
        {
            UserHandler = new UserHandler(this);
            OrderHandler = new OrderHandler(this);
        }

        public ICommand CreatUserCommand
        {
            get { return _createUserCommand ?? (_createUserCommand = new RelayCommand(UserHandler.CreateUser)); }
            set { _createUserCommand = value; }
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(UserHandler.LoginUser)); }
            set { _loginCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
