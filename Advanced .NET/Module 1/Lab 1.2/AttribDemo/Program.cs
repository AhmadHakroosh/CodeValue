using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        public static bool AnalayzeAssembly(Assembly asm)
        {
            Type[] types;
            bool Approved = true;
            types = asm.GetTypes();

            foreach (Type type in types)
            {
                object[] customAttributes = type.GetCustomAttributes(typeof(CodeReviewAttribute), false);

                Console.WriteLine($"Code review for {type.Name}  Length: {customAttributes.Length}");

                foreach (CodeReviewAttribute Attribute in customAttributes)
                {
                    Console.WriteLine($"Name: {Attribute.Name} Date: {Attribute.ReviewDate.ToShortDateString()} Approved: {Attribute.Approved} ");

                    if (!Attribute.Approved)
                    {
                        Approved = false;
                    }
                }

                Console.WriteLine();
            }

            return Approved;
        }

        static void Main(string[] args)
        {

           bool res = AnalayzeAssembly(Assembly.GetExecutingAssembly());

            if (res)
                Console.WriteLine("Approved!");

            else
                Console.WriteLine("Part of the reviewed types were not approved!");

            Console.WriteLine();
            
            Console.WriteLine(AnalayzeAssembly(typeof(int).Assembly));

            Console.ReadLine();
        }
    }
}
