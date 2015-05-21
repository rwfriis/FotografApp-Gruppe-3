using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografApp.Model
{
    class Register
    {
        //private string name;
        //private string password;
        //private string confirmPassword;
        //private string email;
        //private string tlf;

        public void ValidateRegistration(string name, string password, string confirmPassword, string email, string tlf)
        {
            if (!name.Contains(null) || !password.Contains(null) && !confirmPassword.Contains(null) || !email.Contains(null) || !tlf.Contains(null))
            {
                if (!email.Contains("Denne if skal checke databasen for a se om emailen allerede findes i databasen"))
                {
                    if (password.Equals(confirmPassword) && password.Length < 51 && password.Length > 5)
                    {
                        if (name.Length < 10 && name.Length > 50)
                        {
                            if (tlf.Length.Equals(8))
                            {
                                if (email.Length < 51)
                                {
                                    //Add to database with values
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
                //Popup with text: Please fill all info
            }
        }
    }
}
