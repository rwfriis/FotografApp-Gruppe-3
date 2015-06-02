using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using FotografApp.Model;
using FotografApp.Persistency;
using FotografApp.View;
using FotografApp.ViewModel;

namespace FotografApp.Handler
{
    public class UserHandler
    {
        private MainViewModel ViewModel { get; set; }

        public UserHandler(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public void CreateUser()
        {
            if (!ViewModel.ValidateRegister()) return;
            if (Register.ValidateUserRegistration(ViewModel.RName, ViewModel.RPassword, ViewModel.RcPassword, ViewModel.REmail, ViewModel.RTlf))
            {
                ViewModel.RegisterStatusText = "Du er registreret";
                ViewModel.ResetText();
            }
            else ViewModel.RegisterStatusText = "Der opstod en fejl";
        }

        public bool DeleteUser(int id)
        {
            return DatabasePersistencyHandler.Instance.RemoveUser(id);
        }

        public void LogoutUser()
        {
            Singleton.Instance.CurrentUser = null;
            ViewModel.SetLoginButton();
            ViewModel.OrdersCollection.Clear();
            ViewModel.ResetText();
        }

        public void LoginUser()
        {
            if (!ViewModel.ValidateLogin()) return;
            if (Login.LoginAsUser(ViewModel.Email, ViewModel.Password))
            {
                ViewModel.SetLoginButton();
                ViewModel.ResetText();
                ViewModel.LoginStatusText = "Logget ind";
            }
            else
            {
                ViewModel.LoginStatusText = "Forkert email eller password";
            }
            
        }
    }
}
