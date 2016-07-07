using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[5];

            customers[0] = new Customer("Ahmad", 203622162, "Kafr Kanna");
            customers[1] = new Customer("Mohammad", 203624356, "Kafar Kanna");
            customers[2] = new Customer("Malak", 262212862, "Kfar Kanna");
            customers[3] = new Customer("Manar", 123456789, "Kafr Qanna");
            customers[4] = new Customer("Alaa", 987654321, "Kafar Qanna");

            int i = 1;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{i++}. {customer.Name}, {customer.ID}, {customer.Address}");
            }

            Array.Sort(customers);

            i = 1;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{i++}. {customer.Name}, {customer.ID}, {customer.Address}");
            }

            AnotherCustomerComparer comparer = new AnotherCustomerComparer();

            Array.Sort(customers, comparer);

            i = 1;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{i++}. {customer.Name}, {customer.ID}, {customer.Address}");
            }

            Console.ReadLine();
        }
    }
}
