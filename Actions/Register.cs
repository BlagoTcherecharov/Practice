using Bank_account.Data;
using JSON_config;
using Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Passwords;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration
{
    internal class Register
    {
        private string email;
        private string password = null;
        private string password_confirm = null;
        public static void register()
        {
            string email;
            string password = null;
            string password_confirm = null;
            
            Console.WriteLine("CREATE NEW ACCOUNT\n");
            Console.Write("Email: ");
            email = Console.ReadLine();
            do
            {
                Console.Write("Password: ");
                password = Password.password();
                Console.Write("\nConfirm password: ");
                password_confirm = Password.password();
                Console.WriteLine();
            } while (password != password_confirm);
            Console.Clear();

            var config = Configuration.GetConfiguration();

            using (var context = new AppDbContext(config))
            {
                context.Database.OpenConnection();
                try
                {
                    password = Crypting.encrypt(password);
                    var newAccount = new Account { Email = email, Password = password };
                    context.Accounts.Add(newAccount);
                    context.SaveChanges();
                    Console.WriteLine("New account created with email: " + newAccount.Email);
                    Console.WriteLine("Login to view bank account!\n");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                }
            }
        }
    }
}
