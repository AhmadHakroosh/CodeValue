using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    //The class file (Class1.cs) should have a better name.
    public class Account
    {
        internal Account(int id)
        {
            ID = id;
        }

        public int ID { get; private set; }

        public double Balance { get; private set; }

        //A console.wrtieline isn't a good idea. How should you konw whether the deposit succedded or not?
        //How will you test your code via UnitTests?
        //This should throw an exception.
        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Please enter a positive number!");
            }
            else
            {
                Balance += amount;
            }
        }

        //A console.wrtieline isn't a good idea. How should you konw whether the deposit succedded or not?
        //How will you test your code via UnitTests?
        //This should throw an exception.
        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Please enter a positive number!");
            }

            if (Balance < amount)
            {
                Console.WriteLine("You can not withdraw this amount of money!");
            }

            else
            {
                Balance -= amount;
            }
        }

        //Nice
        public void Transfer(Account account, double amount)
        {
            Withdraw(amount);
            account.Deposit(amount);
        }
    }

    //nice.
    public static class AccountFactory
    {
        private static int id = 1;

        public static Account CreateAccount(double balance)
        {
            Account account = new Account(id++);
            account.Deposit(balance);
            return account;
        }
    }
}
