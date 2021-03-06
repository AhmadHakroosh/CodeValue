﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    public class A
    {
        public string Hello (string name)
        {
            return "Hello " + name;
        }
    }

    public class B
    {
        public string Hello (string name)
        {
            return "Bonjour " + name;
        }
    }

    public class C
    {
        public string Hello (string name)
        {
            return "Nihau " + name;
        }
    }

    class Program
    {
        public static string  InvokeHello(Object obj, string name)
        {
            Type type = obj.GetType();
            
            MethodInfo info = type.GetMethod("Hello", new Type[] {typeof(string)});

            //You should check wither this method exists or not.
            return info.Invoke(obj, new object[] { name }).ToString();
        }


        static void Main(string[] args)
        {
            //Usually we use the alias object instead of Object, hense the small letter 'o'. 'object' will be compiled to System.Object.
            //Nice
            Object [] greetings =  new object[]{ new A(), new B(), new C()};

            foreach (var greeting in greetings)
            {
                Console.WriteLine(InvokeHello(greeting,"Ahmad Hakroosh"));
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
