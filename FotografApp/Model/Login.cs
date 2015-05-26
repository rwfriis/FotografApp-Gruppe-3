using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using FotografApp.Persistency;

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

        public bool UserDoesNotExist { get; set; }
        public bool PasswordIsWrong { get; set; }

        public void LoginAsUser(string email, string password)
        {
            List<User> user = DatabasePersistencyHandler.Instance.GetUsers();
            bool exist;
            bool passwordIsTrue;

            foreach (var users in user)
            {
                if (users.Email.Equals(email))
                {
                    exist = true;
                    if (users.Password.Equals(password))
                        passwordIsTrue = true;
                }
            }

            if (exist == true)
            {
                if (passwordIsTrue == true)
                {
                    _isLoggedIn = true;
                    PasswordIsWrong = false;
                    UserDoesNotExist = false;
                }
                else
                {
                    PasswordIsWrong = true;
                }
            }
            else
            {
                UserDoesNotExist = true;
            }
        }
    }
}