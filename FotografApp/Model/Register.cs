using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Persistency;

namespace FotografApp.Model
{
    class Register
    {
        public static void ValidateRegistration(string name, string password, string confirmPassword, string email, string tlf)
        {
            List<User> user = DatabasePersistencyHandler.Instance.GetUsers();
            bool exist = false;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(confirmPassword) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(tlf))
            {
                foreach (var users in user)
                {
                    if (users.Email.Equals(email))
                    {
                        exist = true;
                    }
                }
                if (exist == false)
                    {
                        if (password.Equals(confirmPassword) && password.Length < 51 && password.Length >= 5)
                        {
                            if (name.Length > 5 && name.Length < 51)
                            {
                                if (tlf.Length.Equals(8))
                                {
                                    if (email.Length < 51)
                                    {
                                        var userToBeAdded = new User(name, password, email, tlf);
                                        DatabasePersistencyHandler.Instance.AddUser(userToBeAdded);
                                    }
                                    else
                                    {
                                        //Email is too long
                                    }
                                }
                                else
                                {
                                    //Popup with text: Only enter your phone number, no country code
                                }
                            }
                            else if (name.Length > 50)
                            {
                                //Popup with text: Name is too long, only first and last name
                            }
                            else
                            {
                                //Popup with text: Name is too short, remember to add last name
                            }
                        }
                        else
                        {
                            //Error in password popup
                        }
                }
                else
                {
                    //This email already have an account
                }
            }
            else
            {
                //Please fill all information boxes.
            }
        }
    }
}