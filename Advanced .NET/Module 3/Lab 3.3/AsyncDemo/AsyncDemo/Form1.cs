using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        delegate IEnumerable<int> CalcPrimes(int first, int last);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // "d" is bad name, the name should cleare
            var d = new CalcPrimes(CalcPrimesImpl);

            // no validation for input, use TryParse
            d.BeginInvoke(int.Parse(tbFirst.Text), int.Parse(tbLast.Text), ar =>
            {
                var result = d.EndInvoke(ar);
                this.BeginInvoke(new Action(() =>
                {
                    foreach (var item in result)
                        listBox1.Items.Add(item);
                }));
            }, null);
        }
        // "CalcPrimesImpl" bad name, CalculatePrimeNumbers better
        IEnumerable<int> CalcPrimesImpl(int first, int last)
        {
            return Enumerable.Range(first, last).Where(v => IsPrime(v)).ToArray();
        }

        // Taken from stackoverflow
        bool IsPrime(int number)
        {
            Thread.Sleep(1);

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
