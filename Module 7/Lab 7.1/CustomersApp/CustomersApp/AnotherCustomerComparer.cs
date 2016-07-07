using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class AnotherCustomerComparer : IComparer<Customer>
    {
        int IComparer<Customer>.Compare(Customer x, Customer y) => x.ID.CompareTo(y.ID);
    }
}
