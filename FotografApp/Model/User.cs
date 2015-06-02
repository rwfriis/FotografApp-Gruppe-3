using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Persistency;
using FotografApp.ViewModel;
using Newtonsoft.Json;

namespace FotografApp.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public int TypeOfUserId { get; set; }
        public int Id { get; set; }

        public User(string name, string password, string email, string tlf)
        {
            Name = name;
            Password = password;
            Email = email;
            Tlf = tlf;
            TypeOfUserId = 0;
        }

        [JsonConstructor]
        public User(string name, string password, string email, string tlf, int typeOfUser, int id)
        {
            Name = name;
            Password = password;
            Email = email;
            Tlf = tlf;
            TypeOfUserId = typeOfUser;
            Id = id;
        }

        public User(string email)
        {
            var users = new List<User>();
            users = DatabasePersistencyHandler.Instance.GetUsers();

            foreach (var user in users)
            {
                if (email.Equals(user.Email))
                {
                    user.Name = Name;
                    user.Password = Password;
                    user.Email = Email;
                    user.Tlf = Tlf;
                    break;
                }
            }
        }
    }
}