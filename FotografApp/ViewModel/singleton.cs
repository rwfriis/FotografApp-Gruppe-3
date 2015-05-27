using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Model;

namespace FotografApp.ViewModel
{
    class Singleton
    {
        private static Singleton _instance;

        public User CurrentUser { get; set; }
        public MainViewModel MainViewModel { get; set; }


        public static Singleton Instance
        {
            get { return _instance ?? (_instance = new Singleton()); }
        }

        private Singleton()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
