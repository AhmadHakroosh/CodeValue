using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    //No UnitTests.
    //Did you consider to extract the calculation logic to a different class and possibly file?
    //the convention is to use aliases of known types such as double, int, string, etc...double will compile to System.Double, int will compile to System.Int32 and string will compile to System.String.
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
                    //Hmm the IndexOf is redundant in this case. You could have used the returned indnex of IndexOf to calculate the result dynamically.
                    //Maybe instead of array of operators, you could have an array of methods, when each method is the logic of an operator
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
