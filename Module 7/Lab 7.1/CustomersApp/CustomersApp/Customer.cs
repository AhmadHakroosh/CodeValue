using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; }
        public int ID { get; }
        public string Address { get; }

        public Customer(string name, int id, string address)
        {
            Name = name;
            ID = id;
            Address = address;
        }

        int IComparable<Customer>.CompareTo(Customer other) => String.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        bool IEquatable<Customer>.Equals(Customer other) => other != null && (Name.Equals(other.Name) && ID.Equals(other.ID));
    }
}
