using Microsoft.Extensions.Configuration;
using Registration;
using Signin;
using ViewBalance;
using Deposing;
using Withdrawal;
using Borrow;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;


namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            int entry = 0;
            do
            {
                Console.WriteLine("Would you like to:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.Write("Pick your choice: ");
                entry = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (entry)
                {
                    case 1:
                        login.login();
                        break;
                    case 2:
                        Register.register();
                        login.login();
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            } while (entry != 1 && entry != 2);
            Console.Clear();

            string email = login.propEmail;
            Console.WriteLine("You have succesfully logged in!");

            bool logged = true;
            while (logged == true)
            {
                int action = 0;
                while (action != 5)
                {
                    Console.WriteLine("Would you like to:");
                    Console.WriteLine("1. View balance and loan");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Borrow");
                    Console.WriteLine("5. Log out");
                    Console.Write("Your action: ");
                    action = int.Parse(Console.ReadLine());

                    Console.Clear();
                    switch (action)
                    {
                        case 1:
                            Balance.view(email);
                            Console.WriteLine("\nPress enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            Deposit.deposit(email);
                            Console.WriteLine("\nPress enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Withdraw.withdraw(email);
                            Console.WriteLine("\nPress enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            Loan.loan(email);
                            Console.WriteLine("\nPress enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 5:
                            logged = false;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                    Console.Clear();
                }
            }
            login.propEmail = null;
            Console.WriteLine("You have succesfully logged out!");
        }
    }
}