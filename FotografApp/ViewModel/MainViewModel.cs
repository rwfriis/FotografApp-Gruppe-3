using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FotografApp.Annotations;
using FotografApp.Common;
using FotografApp.Handler;
using FotografApp.Model;

namespace FotografApp.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _createUserCommand;
        private ICommand _loginCommand;
        private ICommand _logoutCommand;
        
        private string _login = "Visible";
        private string _logout = "Collapsed";
        private string _typeVisibility = "Visible";
        private static int _mType;

        public OrderHandler OrderHandler { get; set; }
        public UserHandler UserHandler { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string RName { get; set; }
        public static string REmail { get; set; }
        public static string RPassword { get; set; }
        public static string RCPassword { get; set; }
        public static string RTlf { get; set; }
        public static string MAddress { get; set; }
        public static DateTime MDateTime { get; set; }
        public static string MAntal { get; set; }

        public string TypeVisibility
        {
            get { return _typeVisibility; }
            set { _typeVisibility = value; OnPropertyChanged();}
        }


        public static int MType
        {
            get { return _mType; }
            set { _mType = value; OrderTypeChange();}
        }

        public static int MPortraits { get; set; }
        public static int MPrice { get; set; }
        public static string MName { get; set; }

        public MainViewModel()
        {
            UserHandler = new UserHandler(this);
            OrderHandler = new OrderHandler(this);
            Singleton.Instance.MainViewModel = this;
        }

        public string VisibleLogin
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        public string VisibleLogout
        {
            get { return _logout; }
            set { _logout = value; OnPropertyChanged(); }
        }

        public static void OrderTypeChange()
        {
            Singleton.Instance.MainViewModel.TypeVisibility = MType == 4 ? "Visible" : "Collapsed";
        }

        public ICommand CreateUserCommand
        {
            get { return _createUserCommand ?? (_createUserCommand = new RelayCommand(UserHandler.CreateUser)); }
            set { _createUserCommand = value; }
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(UserHandler.LoginUser)); }
            set { _loginCommand = value; }
        }

        public ICommand LogoutCommand
        {
            get { return _logoutCommand ?? (_logoutCommand = new RelayCommand(UserHandler.LogoutUser)); }
            set { _logoutCommand = value; }
        }

        public void SetLoginButton()
        {
            if (Singleton.Instance.CurrentUser != null)
            {
                VisibleLogin = "Collapsed";
                VisibleLogout = "Visible";
            }
            else
            {
                VisibleLogout = "Collapsed";
                VisibleLogin = "Visible";
            }
            Email = "";
            Password = "";
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
