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
                Console.WriteLine("4. Quit");

                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.Write("Enter the amount you want to deposit: ");
                        amount = int.Parse(Console.ReadLine());
                        yourAccount.Deposit(amount);
                        break;

                    case "2":
                        Console.Write("Enter the amount you want to deposit: ");
                        amount = int.Parse(Console.ReadLine());
                        yourAccount.Withdraw(amount);
                        break;

                    case "3":
                        Console.WriteLine($"Your account balance is ${yourAccount.Balance}");
                        break;

                    case "4":
                        Console.WriteLine("Good Bye!");
                        return;
                }

                Console.WriteLine("");
            }
        }
    }
}
