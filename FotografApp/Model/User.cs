using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Persistency;

namespace FotografApp.Model
{
    class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public bool TypeOfUser { get; set; }

        public User(string name, string password, string email, string tlf)
        {
            Name = name;
            Password = password;
            Email = email;
            Tlf = tlf;
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
                }
            }
        }
    }
}