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

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();
            tbTo.Text = int.MaxValue.ToString();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            btnCalculate.Enabled = false;

            var from = int.Parse(tbFrom.Text);
            var to = int.Parse(tbTo.Text);

            ThreadPool.QueueUserWorkItem(s =>
            {
                List<int> result = new List<int>();

                for (int i = from; i < to && !_cts.Token.IsCancellationRequested; i++)
                {
                    if (isPrime(i))
                        result.Add(i);
                }

                if (!_cts.Token.IsCancellationRequested)
                {
                    Invoke(new Action(() =>
                    {
                        foreach (var item in result)
                        {
                            listBox1.Items.Add(item.ToString());
                        }
                    }));
                }

                Invoke(new Action(() => btnCalculate.Enabled = true));
            });
        }
        
        static bool isPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
    }
}
