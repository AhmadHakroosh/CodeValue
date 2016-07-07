using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2;
            String[] validOps = {"+", "-", "*", "/"};

            while (true)
            {
                Console.WriteLine("Enter the operation you want to execute, for example 2 + 1");
                String op = Console.ReadLine();
                String[] arguments = op.Split(' ');

                if (Double.TryParse(arguments[0], out num1) && Double.TryParse(arguments[2], out num2))
                {
                    if (Array.IndexOf(validOps, arguments[1]) > -1)
                    {
                        if (arguments[1].Equals("+"))
                        {
                            Console.WriteLine($"{num1 + num2}");
                        }

                        else if (arguments[1].Equals("-"))
                        {
                            Console.WriteLine($"{num1 - num2}");
                        }

                        else if (arguments[1].Equals("*"))
                        {
                            Console.WriteLine($"{num1 * num2}");
                        }

                        else if (arguments[1].Equals("/"))
                        {
                            if (num2 != 0)
                            {
                                Console.WriteLine($"{num1 / num2}");
                            }
                            else
                            {
                                Console.WriteLine("Division by zero!");
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine($"{arguments[1]} is not a valid operation!");
                    }
                }

                else
                {
                    Console.WriteLine("You did not enter numeric values!");
                }
            }
        }
    }
}
