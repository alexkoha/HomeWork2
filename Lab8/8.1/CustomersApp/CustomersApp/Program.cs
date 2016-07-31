using System;
using System.Collections.Generic;

namespace CustomersApp
{
    public delegate bool CustomerFilter(Customer customer);    

    public class AnotherCustomerComparer : IComparer<Customer> 
    {
        public int Compare(Customer x, Customer y)
        {
            if (y == null && x == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (x.ID == y.ID) return 0;
            if (x.ID < y.ID) return -1;
            return 1;
        }
    }

    class Program
    {
        static IEnumerable<Customer> GetCustomers(IEnumerable<Customer> arr, CustomerFilter del)
        {
            //Consier the use of yield return.
            //foreach (var customer in arr)
            //{
            //    if (del(customer))
            //    {
            //        yield return customer;
            //    }
            //}

            var temp = new List<Customer>();
            foreach (var item in arr)
            {
                //The conveintion in C# is to start body expressions in a seperate line and with bracets "{ }", even for oneliners
                if (del(item)) temp.Add(item);
            }
            return temp;
        }

        static void Main()
        {
            var listCust = new List<Customer>()
            {
                new Customer("Alex", 1, "Karmiel"),
                new Customer("Zlex", 106, "Karmiel"),
                new Customer("Flex", 4, "Karmiel"),
                new Customer("Llex", 55, "Karmiel"),
                new Customer("Bob", 150, "Karmiel"),
                new Customer("Xore", 457, "Karmiel"),
                new Customer("Pom", 2, "Karmiel")
            };

            Console.WriteLine("Get customers with name that starts with the letters A-K :");
            Console.WriteLine("----------------------------------------------------------");

            CustomerFilter filterAK = Customer.CustomerAK;

            var afterAK = GetCustomers(listCust, filterAK);

            foreach (var item in afterAK)
            {
                item.Display();
            }

            Console.WriteLine("Get customers with name that starts with the letters L-Z :");
            Console.WriteLine("----------------------------------------------------------");


            CustomerFilter customerLZ = delegate(Customer customer) // anonymus delegate
            {
                for (char i = 'L'; i <= 'Z'; i++)
                {
                    if (customer.Name[0] == i) return true;
                }
                return false;
            };

            var afetrLZ = GetCustomers(listCust, customerLZ);

            foreach (var item in afetrLZ)
            {
                item.Display();
            }

            Console.WriteLine("Get customers with id less than 100 :");
            Console.WriteLine("------------------------------------");

            CustomerFilter less100ID = custumer => custumer.ID < 100 ; // lambda expression

            var AfterLess100Id = GetCustomers(listCust, less100ID);
            
            //Consider extracting this logic to another method
            foreach (var item in AfterLess100Id)
            {
                item.Display();
            }


        }
    }
}
