using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using FotografApp.Persistency;
using FotografApp.View;

namespace FotografApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _createUserCommand;
        private ICommand _loginCommand;
        private ICommand _logoutCommand;
        private ICommand _createOrderCommand;
        private ICommand _deleteOrderCommand;
        
        private string _login = "Visible";
        private string _logout = "Collapsed";
        private string _typeVisibility = "Collapsed";
        private int _mType;
        private DateTimeOffset _mDateTime = DateTime.Now;
        private DateTimeOffset _mTime = DateTime.Now;
        private string _catErrorText;
        private string _dateErrorText;
        private string _timeErrorText;
        private string _addErrorText;
        private string _orderStatusText;
        private string _loginStatusText;
        private string _deleteStatusText;
        private string _password;
        private string _email;
        private string _registerStatusText;
        private string _rName;
        private string _rEmail;
        private string _rPassword;
        private string _rcPassword;
        private string _rTlf;
        private string _mAddress;
        private string _mAntal;
        private int _mPrice;
        private string _mName;
        private ObservableCollection<Orders> _ordersCollection;
        

        public OrderHandler OrderHandler { get; set; }
        public UserHandler UserHandler { get; set; }

        #region PropertyChanged attributes
        public DateTimeOffset MDateTime
        {
            get { return _mDateTime; }
            set { _mDateTime = value; OnPropertyChanged(); }
        }

        public DateTimeOffset MTime
        {
            get { return _mTime; }
            set { _mTime = value; OnPropertyChanged(); }
        }

        public string DeleteStatusText
        {
            get { return _deleteStatusText; }
            set { _deleteStatusText = value; OnPropertyChanged(); }
        }

        public string RName
        {
            get { return _rName; }
            set { _rName = value; OnPropertyChanged(); }
        }

        public string REmail
        {
            get { return _rEmail; }
            set { _rEmail = value; OnPropertyChanged(); }
        }

        public string RPassword
        {
            get { return _rPassword; }
            set { _rPassword = value; OnPropertyChanged(); }
        }

        public string RcPassword
        {
            get { return _rcPassword; }
            set { _rcPassword = value; OnPropertyChanged(); }
        }

        public string RTlf
        {
            get { return _rTlf; }
            set { _rTlf = value; OnPropertyChanged(); }
        }

        public string MAddress
        {
            get { return _mAddress; }
            set { _mAddress = value; OnPropertyChanged(); }
        }

        public string MAntal
        {
            get { return _mAntal; }
            set { _mAntal = value; OnPropertyChanged(); }
        }

        public int MPrice
        {
            get { return _mPrice; }
            set { _mPrice = value; OnPropertyChanged(); }
        }

        public string MName
        {
            get { return _mName; }
            set { _mName = value; OnPropertyChanged(); }
        }

        public string RegisterStatusText
        {
            get { return _registerStatusText; }
            set { _registerStatusText = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        public string LoginStatusText
        {
            get { return _loginStatusText; }
            set { _loginStatusText = value; OnPropertyChanged(); }
        }

        public string OrderStatusText
        {
            get { return _orderStatusText; }
            set { _orderStatusText = value; OnPropertyChanged();}
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
            set { _typeVisibility = value; OnPropertyChanged(); }
        }
        #endregion

        public Orders SelectedOrder { get; set; }

        public int MType
        {
            get { return _mType; }
            set { _mType = value; OrderTypeChange();}
        }

        public ObservableCollection<Orders> OrdersCollection
        {
            get { return _ordersCollection; }
            set { _ordersCollection = value; OnPropertyChanged(); }
        }

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
            GetOrdersFromUser();
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
            OrderStatusText = "";
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
            if (!check)
            {
                OrderStatusText = "Udfyld alle felterne korrekt";
            }
            return check;
        }

        public Boolean ValidateLogin()
        {
            LoginStatusText = "";
            var check = true;
            if (string.IsNullOrEmpty(Email))
            {
                check = false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                check = false;
            }
            if (!check)
            {
                LoginStatusText = "Udfyld begge felter";
            }
            return check;
        }

        public Boolean ValidateRegister()
        {
            RegisterStatusText = "";
            var check = true;
            if (string.IsNullOrEmpty(REmail) || string.IsNullOrEmpty(RPassword) || string.IsNullOrEmpty(RcPassword) || string.IsNullOrEmpty(RName) || string.IsNullOrEmpty(RTlf))
            {
                check = false;
                RegisterStatusText = "Udfyld all felter";
            }
            else if (RPassword != RcPassword)
            {
                check = false;
                RegisterStatusText = "Password skal være ens";
            }
            return check;
        }

        public void OrderTypeChange()
        {
            Singleton.Instance.MainViewModel.TypeVisibility = MType == 4 ? "Visible" : "Collapsed";
        }

        public void GetOrdersFromUser()
        {
            OrdersCollection = DatabasePersistencyHandler.Instance.GetOrdersFromUser(Singleton.Instance.CurrentUser);
        }

        public void SetLoginButton()
        {
            if (Singleton.Instance.CurrentUser != null)
            {
                VisibleLogin = "Collapsed";
                VisibleLogout = "Visible";
                GetOrdersFromUser();
            }
            else
            {
                VisibleLogout = "Collapsed";
                VisibleLogin = "Visible";
            }
            LoginStatusText = "";
        }

        public void ResetText()
        {
            Email = "";
            Password = "";
            REmail = "";
            RPassword = "";
            RcPassword = "";
            RTlf = "";
            RName = "";
            MAddress = "";
            MAntal = "";
            MDateTime = DateTime.Now;
            MName = "";
            MTime = DateTime.Now;
            MType = 0;
            CatErrorText = "";
            AddErrorText = "";
            DateErrorText = "";
            TimeErrorText = "";
        }

        #region ICommands

        public ICommand DeleteOrderCommand
        {
            get { return _deleteOrderCommand ?? (_deleteOrderCommand = new RelayCommand(OrderHandler.DeleteOrder)); }
            set { _deleteOrderCommand = value; }
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
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
