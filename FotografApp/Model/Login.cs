using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using FotografApp.Persistency;
using FotografApp.ViewModel;

namespace FotografApp.Model
{
    class Login
    {
        private static bool _isLoggedIn = false;

        public static bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }

        public static bool UserDoesNotExist { get; set; }
        public static bool PasswordIsWrong { get; set; }

        public static void LoginAsUser(string email, string password)
        {
            User user = DatabasePersistencyHandler.Instance.GetUser(email, password);
            if (user != null)
            {
                Singleton.Instance.CurrentUser = user;
            }
        }
    }
}