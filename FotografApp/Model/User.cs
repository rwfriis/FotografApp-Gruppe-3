using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Persistency;
using FotografApp.ViewModel;

namespace FotografApp.Model
{
    class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public int TypeOfUser { get; set; }
        public int Id { get; set; }

        public User(string email, string name, string tlf, string password, int type, int id)
        {
            Name = name;
            Password = password;
            Email = email;
            Tlf = tlf;
            TypeOfUser = type;
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