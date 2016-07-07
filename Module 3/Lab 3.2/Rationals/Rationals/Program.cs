using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public struct Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public double DoubleNumerator
        {
            get { return (double) Numerator; }
        }

        public double DoubleDenominator
        {
            get { return (double) Denominator; }
        }

        public Rational(int num, int den)
        {
            if (den != 0)
            {
                this.Numerator = num;
                this.Denominator = den;
            }

            else
            {
                this.Numerator = 0;
                this.Denominator = 1;
            }
        }

        public Rational(int num)
        {
            this.Numerator = num;
            this.Denominator = 1;
        }

        public Rational Add(Rational num2)
        {
            int num = this.Numerator*num2.Denominator + this.Denominator*num2.Numerator;
            int den = this.Denominator*num2.Denominator;
            Rational res = new Rational(num, den);
            res.Reduce();
            return res;
        }

        public Rational Mul(Rational num2)
        {
            int num = this.Numerator*num2.Numerator;
            int den = this.Denominator*num2.Denominator;
            Rational res = new Rational(num, den);
            res.Reduce();
            return res;
        }

        public void Reduce()
        {
            int gcd = GCD(this.Numerator, this.Denominator);
            this.Numerator /= gcd;
            this.Denominator /= gcd;
        }

        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }

        public bool Equals(Rational num)
        {
            this.Reduce();
            num.Reduce();

            return this.Numerator == num.Numerator && this.Denominator == num.Denominator ? true : false;
        }

        private int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a%b;
                a = b;
                b = rem;
            }

            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rational num1 = new Rational(4, 8);
            Rational num2 = new Rational(3, 9);
            Rational num3 = new Rational(4, 6);

            Rational num4 = num1.Add(num2);
            Rational num5 = num2.Mul(num3);

            Rational num6 = new Rational(1, 2);
            Rational num7 = new Rational(5);
            Rational num8 = new Rational(1, 0);

            Console.WriteLine($"{num1} + {num2} = {num4}");
            Console.WriteLine($"{num2} * {num3} = {num5}");
            Console.WriteLine($"{num1} == {num6} ? {num1.Equals(num6)}");
            Console.WriteLine($"{num7}");
            Console.WriteLine($"{num8}");
            Console.ReadLine();
        }
    }
}
