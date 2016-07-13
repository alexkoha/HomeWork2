using System;

namespace DynInvoke
{
    public class A
    {
        public string Hello(string some)
        {
            return "Hello " + some;
        }
    }
    public class B
    {
        public string Hello(string some)
        {
            return "Bonjour " + some;
        }
    }
    public class C
    {
        public string Hello(string some)
        {
            return "Nihau " + some;
        }
    }

    class Program
    {
        static void InvokeHello(object obj, string str)
        {
            Console.WriteLine(obj.GetType().GetMethod("Hello").Invoke(obj , new object[] {str}));
            //dynamic dynamicClass = obj;
            //Console.WriteLine(dynamicClass.Hello(str));
        }

        static void Main()
        {
            var a = new A();
            var b = new B();
            var c = new C();

            InvokeHello(a,"Alex");
            InvokeHello(b, "Alex");
            InvokeHello(c, "Alex");

        }
    }
}
