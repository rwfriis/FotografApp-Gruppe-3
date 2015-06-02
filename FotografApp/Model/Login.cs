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
        public static Boolean LoginAsUser(string email, string password)
        {
            User user = DatabasePersistencyHandler.Instance.GetUser(email, password);
            if (user == null) return false;
            Singleton.Instance.CurrentUser = user;
            return true;
        }
    }
}