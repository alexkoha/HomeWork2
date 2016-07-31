using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        private string _name;
        private int _id;
        private string _address;

        public string Name => _name; // get
        public int ID => _id;  // get

        public Customer(string name, int id, string address)
        {
            _name = name;
            _id = id;
            _address = address;
        }


        public void Display()
        {
            Console.WriteLine("Name : " + _name);
            Console.WriteLine("ID : " + _id);
            Console.WriteLine("Address : " + _address);
            Console.WriteLine();
        }

        public int CompareTo(Customer other)
        {
            //The conveintion in C# is to start body expressions in a seperate line and with bracets "{ }", even for oneliners
            if (other == null) return 1;

            //Read more about cultures and strings in .Net
            return string.Compare(_name, other._name);
        }

        public bool Equals(Customer other)
        {
            if (other == null) return false;

            return (_name == other._name && _id == other._id);
        }

        //Why is this method here and not outside of this class?
        public static bool CustomerAK(Customer customer)
        {
            //this is better.
            //var firstChar = customer.Name[0];
            //if( firstChar >= 'a' && firstChar <= 'k' || firstChar >= 'A' && firstChar <= 'K')
            for (char i = 'A'; i <= 'K'; i++)
            {
                //use the 'Name' property.
                if (customer._name[0] == i) return true;
            }
            return false;
        }


    }
}
