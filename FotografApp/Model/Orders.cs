using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Newtonsoft.Json;

namespace FotografApp.Model
{
    class Orders
    {
        private User user;
        private string address;
        private DateTime dateTime;
        private string type;
        private int portraits;
        private int price;

        [JsonConstructor]
        public Orders(User user, string address, DateTime dateTime, string type, int portraits, int price)
        {
            this.user = user;
            this.address = address;
            this.dateTime = dateTime;
            this.type = type;
            this.portraits = portraits;
            this.price = price;
        }
    }
}
