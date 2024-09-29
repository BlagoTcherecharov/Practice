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

namespace ViewBalance
{
    internal class Balance
    {
        public static void view(string email)
        {
            var config = Configuration.GetConfiguration();

            using (var context = new AppDbContext(config))
            {
                var account = context.Accounts.FirstOrDefault(a => a.Email == email);

                Console.WriteLine($"Balance: {account.Balance:F2}$");
                Console.WriteLine($"Loan: {account.Loan:F2}$");
            }
        }
    }
}
