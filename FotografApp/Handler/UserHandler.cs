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
            Register.ValidateRegistration(_viewModel.Name, _viewModel.Password, _viewModel.ConfirmPassword, _viewModel.Email, _viewModel.Tlf);
        }

        public void CheckUser()
        {
            Login.LoginAsUser(_viewModel.Name, _viewModel.Password);
        } 
    }
}
