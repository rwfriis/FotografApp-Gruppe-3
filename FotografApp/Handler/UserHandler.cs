using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Model;
using FotografApp.View;
using FotografApp.ViewModel;

namespace FotografApp.Handler
{
    class UserHandler
    {
        private MainViewModel _viewModel { get; set; }

        public UserHandler(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public void CreateUser()
        {
            
        }

        public void LogoutUser()
        {
            Singleton.Instance.CurrentUser = null;
            _viewModel.SetLoginButton();
        }

        public void LoginUser()
        {
            Login.LoginAsUser(_viewModel.Email, _viewModel.Password);
            _viewModel.SetLoginButton();
        }
    }
}
