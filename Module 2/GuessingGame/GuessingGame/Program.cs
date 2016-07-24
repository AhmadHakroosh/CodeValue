using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    //Nice.
    class Program
    {
        static void Main(string[] args)
        {
            int guess;

            while (true)
            {
                Console.WriteLine("Try to guess the number!");
                //I have sent various mails about this bug. You should have used Next(1, 101);
                int secret = new Random().Next(1, 100);
                int tries = 7;

                //Did you consider the use of a for loop?
                while (tries > 0)
                {
                    //You are not validation the input.
                    guess = int.Parse(Console.ReadLine());
                    if (guess > secret)
                    {
                        Console.WriteLine("Too Big!");
                    }

                    else if (guess < secret)
                    {
                        Console.WriteLine("Too Small!");
                    }

                    else
                    {
                        Console.WriteLine($"That's great! you guessed the number correctly after {8 - tries} tries!");
                    }

                    --tries;
                }

                Console.WriteLine($"You failed!, The number is {secret}");
            }
        }
    }
}
