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
                var date = new DateTime(ViewModel.MDateTime.Year, ViewModel.MDateTime.Month, ViewModel.MDateTime.Day, ViewModel.MTime.Hour, ViewModel.MTime.Minute, ViewModel.MTime.Second);
                if (Register.ValidateOrderRegistration(Singleton.Instance.CurrentUser, ViewModel.MAddress, date, ViewModel.MType + 1, Convert.ToInt32(ViewModel.MAntal), 0))
                {
                    ViewModel.OrderStatusText = "Bestilling udført";
                    ViewModel.ResetText();
                    ViewModel.GetOrdersFromUser();
                }
                else ViewModel.OrderStatusText = "Der opstod en fejl";
            }
        }

        public void DeleteOrder()
        {
            if (DatabasePersistencyHandler.Instance.RemoveOrder(ViewModel.SelectedOrder))
            {
                ViewModel.DeleteStatusText = "Bestilling slettet";
                ViewModel.GetOrdersFromUser();
            }
            else ViewModel.DeleteStatusText = "Der skete en fejl";
        }

        public void UpdateOrder()
        {
            
        }
    }
}
