using Bank_account.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSON_config;
using Verification;

namespace Deposing
{
    internal class Deposit
    {
        public static void deposit(string email)
        {
            float ammount;
            bool error = true;
            do
            {
                Console.Write("How much would you deposit today: ");
                ammount = float.Parse(Console.ReadLine());
                error = floatVerification.verification(ammount);
                Console.Clear();
                if (error == true)
                    Console.WriteLine("Not a valid deposit");
            } while (error == true);
                
            
            var config = Configuration.GetConfiguration();

            using (var context = new AppDbContext(config))
            {
                var account = context.Accounts.FirstOrDefault(a => a.Email == email);

                account.Balance += ammount;
                context.SaveChanges();
                Console.WriteLine($"New balance: {account.Balance:F2}$");
            }
        }
    }
}
