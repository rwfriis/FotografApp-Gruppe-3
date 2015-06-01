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
        private ICommand _createOrderCommand;
        
        private string _login = "Visible";
        private string _logout = "Collapsed";
        private string _typeVisibility = "Visible";
        private static int _mType;
        private static DateTimeOffset _mDateTime = DateTime.Now;
        private static DateTimeOffset _mTime = DateTime.Now;
        private string _catErrorText;
        private string _dateErrorText;
        private string _timeErrorText;
        private string _addErrorText;

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

        public static DateTimeOffset MDateTime
        {
            get { return _mDateTime; }
            set { _mDateTime = value; }
        }

        public static string MAntal { get; set; }

        public static DateTimeOffset MTime
        {
            get { return _mTime; }
            set { _mTime = value; }
        }

        public string CatErrorText
        {
            get { return _catErrorText; }
            set { _catErrorText = value; OnPropertyChanged(); }
        }

        public string DateErrorText
        {
            get { return _dateErrorText; }
            set { _dateErrorText = value; OnPropertyChanged(); }
        }

        public string TimeErrorText
        {
            get { return _timeErrorText; }
            set { _timeErrorText = value; OnPropertyChanged(); }
        }

        public string AddErrorText
        {
            get { return _addErrorText; }
            set { _addErrorText = value; OnPropertyChanged(); }
        }

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
            if (Singleton.Instance.CurrentUser != null)
            {
                VisibleLogout = "Visible";
                VisibleLogin = "Collapsed";
            }
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

        public Boolean ValidateOrder()
        {
            CatErrorText = "";
            DateErrorText = "";
            TimeErrorText = "";
            AddErrorText = "";
            var check = true;
            if (MType == 4)
            {
                int number;
                if (MAntal == "")
                {
                    check = false;
                    CatErrorText = "Giv et antal";
                }
                else if (!int.TryParse(MAntal, out number))
                {
                    check = false;
                    CatErrorText = "Skal være et helt tal";
                }
            }
            if (MDateTime.Date <= DateTime.Now)
            {
                check = false;
                DateErrorText = "Vælg en dag efter i dag";
            }
            if (MAddress == "")
            {
                check = false;
                AddErrorText = "Skriv din addresse";
            }
            return true;
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

        public ICommand CreateOrderCommand
        {
            get { return _createOrderCommand ?? (_createOrderCommand = new RelayCommand(OrderHandler.CreateOrder)); }
            set { _createOrderCommand = value; }
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
