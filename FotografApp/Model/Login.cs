using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;

namespace FotografApp.Model
{
    class Login
    {
        public void LoginAsUser(string email, string password)
        {
            if (email.Contains("If exist in server") &&
                password.Contains("If corresponds with the pasword of the email"))
            {
                //Log in
            }
            //Popup with text: Failed to login in: Email or password is incorrect
        }
    }
}
