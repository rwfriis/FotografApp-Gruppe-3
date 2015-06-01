using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Model;
using FotografApp.Persistency;
using FotografApp.View;
using FotografApp.ViewModel;

namespace FotografApp.Handler
{
    class OrderHandler
    {
        private MainViewModel ViewModel { get; set; }

        public OrderHandler(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void CreateOrder()
        {
            if (ViewModel.ValidateOrder())
            {
                var date = new DateTime(MainViewModel.MDateTime.Year, MainViewModel.MDateTime.Month, MainViewModel.MDateTime.Day, MainViewModel.MTime.Hour, MainViewModel.MTime.Minute, MainViewModel.MTime.Second);
                Register.ValidateOrderRegistration(Singleton.Instance.CurrentUser, MainViewModel.MAddress, DateTime.Now, MainViewModel.MType, Convert.ToInt32(MainViewModel.MAntal), 0);
            }
        }

        public void DeleteOrder()
        {
            DatabasePersistencyHandler.Instance.RemoveOrder(null);
        }

        public void UpdateOrder()
        {
            
        }
    }
}
