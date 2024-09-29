using Bank_account.Data;
using JSON_config;
using Microsoft.Extensions.Configuration;
using Passwords;
using Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography;

namespace Signin
{
    internal class Login
    {
        private string email;
        private string password;
        private bool accepted = false;

        public string propEmail { get { return email; } set { email = value; } }
        public void login()
        {
            Console.WriteLine("LOGIN\n");

            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Password: ");
                password = Password.password();
                Console.Clear();


                var config = Configuration.GetConfiguration();

                using (var context = new AppDbContext(config))
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Email == email);
                    string decryption = Crypting.decrypt(account.Password);

                    if (account != null && decryption == password)
                    {
                        Console.WriteLine("You have successfully logged in with email " + account.Email + "\n");
                        accepted = true;
                    }
                    else
                    {
                        Console.WriteLine("Account name or password is wrong!\n");
                        Console.WriteLine("1. Would you like to try again");
                        Console.WriteLine("2. Register an account");
                        Console.Write("Your choice: ");
                        int pick = int.Parse(Console.ReadLine());

                        switch (pick) 
                        {
                            case 1:
                                break;
                            case 2:
                                Register.register();
                                accepted = true;
                                break;
                            default: 
                                Console.WriteLine("No such option, we have returned you to the main menu!\n");
                                accepted = true;
                                break;
                        }
                    }
                }
            } while (accepted == false);
                
        }
    }
}
