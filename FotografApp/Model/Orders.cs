using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Newtonsoft.Json;

namespace FotografApp.Model
{
    class Orders
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Portraits { get; set; }
        public int Price { get; set; }
        public int TypeOfId { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }

        public Orders(int userId, DateTime dateTime, int portraits, int price, int typeOfId, string address)
        {
            UserId = userId;
            Date = dateTime;
            Portraits = portraits;
            Price = price;
            TypeOfId = typeOfId;
            Address = address;
        }

        [JsonConstructor]
        public Orders(int id, string address, int typeOfId, int price, int portraits, DateTime dateTime, int userId)
        {
            Id = id;
            Address = address;
            TypeOfId = typeOfId;
            Price = price;
            Portraits = portraits;
            Date = dateTime;
            UserId = userId;
        }
    }
}
