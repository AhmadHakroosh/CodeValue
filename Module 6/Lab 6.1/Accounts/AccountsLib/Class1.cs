using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        internal Account(int id)
        {
            ID = id;
        }

        public int ID { get; private set; }

        public double Balance { get; private set; }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Balance += amount;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
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

        public void Transfer(Account account, double amount)
        {
            double balance = this.Balance;
            try
            {
                Withdraw(amount);
                account.Deposit(amount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("You can not transfer this amount of money, please try again!");
            }
            finally
            {
                Console.WriteLine("A money transfer attempt has been made.");
                Console.WriteLine($"You account's balance was {balance}, and now it is {this.Balance}.");
            }
        }
    }

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
