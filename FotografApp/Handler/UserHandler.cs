using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Model;
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

        public void LoginUser()
        {
            Login.LoginAsUser(_viewModel.email, _viewModel.password);
        }
    }
}
