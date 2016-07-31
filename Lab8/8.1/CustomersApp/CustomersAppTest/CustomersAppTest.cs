
using CustomersApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomersAppTest
{
    //You are testing only the customers, without the delegates :)
    //Cool though.
    [TestClass]
    public class TestCustomerCompareTo
    {
        [TestMethod]
        public void Customer_CompareTo_Names_Simples_Smaller()
        {
            Customer test1 = new Customer("Alex",112233,"Bla");
            Customer test2 = new Customer("Moshe", 221133, "Bla Bla");

            Assert.AreEqual(-1,test1.CompareTo(test2));
        }

        [TestMethod]
        public void Customer_CompareTo_Names_Simples_Bigger()
        {
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Moshe", 221133, "Bla Bla");

            Assert.AreEqual(1, test2.CompareTo(test1));
        }

        [TestMethod]
        public void Customer_CompareTo_Names_Equal()
        {
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Alex", 221133, "Bla Bla");

            Assert.AreEqual(0, test1.CompareTo(test2));
        }
        [TestMethod]
        public void Customer_CompareTo_One_Of_Names_Null()
        {
            Customer test1 = new Customer("Alex", 112233, "Bla");

            Assert.AreEqual(1, test1.CompareTo(null));
        }
    }

    [TestClass]
    public class TestCustomerEqual
    {
        [TestMethod]
        public void Customer_Equal_Simple_False()
        {
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Moshe", 221133, "Bla Bla");

            Assert.AreEqual(false, test1.Equals(test2));
        }

        [TestMethod]
        public void Customer_Equal_Simple_True()
        {
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Alex", 112233, "Bla");

            Assert.AreEqual(true, test1.Equals(test2));
        }

        [TestMethod]
        public void Customer_Equal_Capital_Test()
        {
            Customer test1 = new Customer("alex", 112233, "Bla");
            Customer test2 = new Customer("Alex", 112233, "Bla");

            Assert.AreEqual(false, test1.Equals(test2));
        }

        [TestMethod]
        public void Customer_Equal_One_Of_Object_Null()
        {
            Customer test1 = new Customer("alex", 112233, "Bla");

            Assert.AreEqual(false, test1.Equals(null));
        }
    }

    [TestClass]
    public class TestAnotherCustomerComparerCompare
    {
        [TestMethod]
        public void AnotherCustomerComparer_Compare_Simple_Smaller()
        {
            var a = new AnotherCustomerComparer();
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Moshe", 221133, "Bla Bla");
            
            Assert.AreEqual(-1, a.Compare(test1, test2));
        }

        [TestMethod]
        public void AnotherCustomerComparer_Compare_Simple_Biger()
        {
            var a = new AnotherCustomerComparer();
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Moshe", 221133, "Bla Bla");

            Assert.AreEqual(1, a.Compare(test2, test1));
        }

        [TestMethod]
        public void AnotherCustomerComparer_Compare_One_Null()
        {
            var a = new AnotherCustomerComparer();
            Customer test1 = new Customer("Alex", 112233, "Bla");

            Assert.AreEqual(1, a.Compare(test1, null));
        }

        [TestMethod]
        public void AnotherCustomerComparer_Compare_One_Equal()
        {
            var a = new AnotherCustomerComparer();
            Customer test1 = new Customer("Alex", 112233, "Bla");
            Customer test2 = new Customer("Alex", 112233, "Bla");

            Assert.AreEqual(0, a.Compare(test1, test2));
        }

        [TestMethod]
        public void AnotherCustomerComparer_Compare_Both_Null()
        {
            var a = new AnotherCustomerComparer();

            Assert.AreEqual(0, a.Compare(null, null));
        }
    }
}
