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
    public class OrderHandler
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
                int a;
                if (!int.TryParse(ViewModel.MAntal, out a))
                {
                    a = 0;
                }
                DateTime date = new DateTime(ViewModel.MDateTime.Year, ViewModel.MDateTime.Month, ViewModel.MDateTime.Day, ViewModel.MTime.Hour, ViewModel.MTime.Minute, 0);
                if (Register.ValidateOrderRegistration(Singleton.Instance.CurrentUser, ViewModel.MAddress, date, ViewModel.MType, a, 0))
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
            try
            {
                if (DatabasePersistencyHandler.Instance.RemoveOrder(ViewModel.SelectedOrder.Id))
                {
                    ViewModel.DeleteStatusText = "Bestilling slettet";
                    ViewModel.GetOrdersFromUser();
                }
                else ViewModel.DeleteStatusText = "Der skete en fejl";
            }
            catch (Exception ex)
            {
                ViewModel.DeleteStatusText = "Vælg hvilken bestilling der skal fjernes";
            }
        }

        public void UpdateOrder()
        {
            
        }
    }
}
