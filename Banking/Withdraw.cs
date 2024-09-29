using Bank_account.Data;
using JSON_config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verification;

namespace Withdrawal
{
    internal class Withdraw
    {
        public static void withdraw(string email)
        {
            var config = Configuration.GetConfiguration();
            float ammount, balance;
            bool error = true;

            using (var context = new AppDbContext(config))
            {
                var account = context.Accounts.FirstOrDefault(a => a.Email == email);
                balance = account.Balance;

                do
                {
                    Console.Write("How much would you withdraw today: ");
                    ammount = float.Parse(Console.ReadLine());
                    error = floatVerification.verification(ammount);
                    Console.Clear();
                    if (error == true || balance < ammount)
                        Console.WriteLine("Not a valid withdraw or withdraw is exceeding balance");
                } while (error == true || balance < ammount);

                account.Balance -= ammount;
                context.SaveChanges();
                Console.WriteLine($"New balance: {account.Balance:F2}$");
            }
        }
    }
}
