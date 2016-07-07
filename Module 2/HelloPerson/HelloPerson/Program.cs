using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            //Read the user's name
            String name = Console.ReadLine();
            //Print hello "name"
            Console.WriteLine($"Hello {name}");
            Console.WriteLine("Please enter a number from 1 to 10:");
            //Read the number
            int number = int.Parse(Console.ReadLine());
            //check if a valid number
            while (number > 10 || number < 1)
            {
                Console.WriteLine("Invalid number! Try again:");
                number = int.Parse(Console.ReadLine());
            }
            //loop over number
            for (int i = 0; i < number; ++i)
            {
                for (int j = 0; j < i; ++j)
                    Console.Write(" ");

                Console.WriteLine($"{name}");
            }
        }
    }
}
