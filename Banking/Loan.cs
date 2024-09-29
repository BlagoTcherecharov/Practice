using Bank_account.Data;
using JSON_config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Verification;

namespace Borrow
{
    internal class Loan
    {
        public static void loan(string email)
        {

            var config = Configuration.GetConfiguration();

            using (var context = new AppDbContext(config))
            {
                float loan;
                bool error = true;
                do
                {
                    Console.Write("How much would you like to loan today: ");
                    loan = float.Parse(Console.ReadLine());
                    error = floatVerification.verification(loan);
                    Console.Clear();
                    if (error == true)
                        Console.WriteLine("Not a valid loan");
                } while (error == true);

                var account = context.Accounts.FirstOrDefault(a => a.Email == email);

                account.Loan += loan;
                context.SaveChanges();
                Console.WriteLine($"New loan: {account.Loan:F2}$");
            }
        }
    }
}
