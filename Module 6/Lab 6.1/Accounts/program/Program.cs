using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Account yourAccount = AccountFactory.CreateAccount(0);
            int amount;

            Console.WriteLine("Welcome to your bank account manager! Please select an operation:");
            while (true)
            {
                Console.WriteLine("1. Deposit money to your account");
                Console.WriteLine("2. Withdraw money from your account");
                Console.WriteLine("3. Check your account balance");

                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.Write("Enter the amount you want to deposit: ");
                        amount = int.Parse(Console.ReadLine());
                        try
                        {
                            yourAccount.Deposit(amount);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Please enter a positive amount of money!");
                        }

                        break;

                    case "2":
                        Console.Write("Enter the amount you want to deposit: ");
                        amount = int.Parse(Console.ReadLine());
                        try
                        {
                            yourAccount.Withdraw(amount);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Please enter a positive amount of money!");
                        }

                        break;

                    case "3":
                        Console.WriteLine($"Your account balance is ${yourAccount.Balance}");
                        break;
                }
            }
        }
    }
}
