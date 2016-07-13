using System;

namespace Retionals
{
    
    class Program 
    {
        static void Main()
        {
            Console.WriteLine("\n Test 1 :");
            Console.WriteLine("-------------");

            var oneRetionls = new Retionals(2,8);
            var twoRetionals = new Retionals(4, 16);

            Console.WriteLine("First Retionl : " + oneRetionls.ToString());
            Console.WriteLine("Second Retionl : " + twoRetionals.ToString());
            
            // add
            var addRetionals = oneRetionls + twoRetionals;
            Console.WriteLine("after add : " + addRetionals.ToString());
            //Mul
            var mulRetionals = oneRetionls*twoRetionals;
            Console.WriteLine("after mul : " + mulRetionals.ToString());
            //dec
            var decRetionals = oneRetionls - twoRetionals;
            Console.WriteLine("after dec : " + decRetionals.ToString());
            //div
            var divRetionals = oneRetionls / twoRetionals;
            Console.WriteLine("after div : " + divRetionals.ToString());

            Console.WriteLine("equal ? " + oneRetionls.Equals(twoRetionals));

            Console.WriteLine("\n Test 2 :");
            Console.WriteLine("-------------");

            oneRetionls = new Retionals(3, 8);
            twoRetionals = new Retionals(4, 7);

            Console.WriteLine("First Retionl : " + oneRetionls.ToString());
            Console.WriteLine("Second Retionl : " + twoRetionals.ToString());

            // add
            addRetionals = oneRetionls + twoRetionals;
            Console.WriteLine("after add : " + addRetionals.ToString());
            //Mul
            mulRetionals = oneRetionls * twoRetionals;
            Console.WriteLine("after mul : " + mulRetionals.ToString());
            //dec
            decRetionals = oneRetionls - twoRetionals;
            Console.WriteLine("after dec : " + decRetionals.ToString());
            //div
            divRetionals = oneRetionls / twoRetionals;
            Console.WriteLine("after div : " + divRetionals.ToString());

            Console.WriteLine("equal ? " + oneRetionls.Equals(twoRetionals));

            Console.WriteLine("\n Test 2 :");
            Console.WriteLine("-------------");

            oneRetionls = new Retionals(0, 0);
            twoRetionals = new Retionals(4, 7);

            Console.WriteLine("First Retionl : " + oneRetionls.ToString());
            Console.WriteLine("Second Retionl : " + twoRetionals.ToString());

            // add
            addRetionals = oneRetionls + twoRetionals;
            Console.WriteLine("after add : " + addRetionals.ToString());
            //Mul
            mulRetionals = oneRetionls * twoRetionals;
            Console.WriteLine("after mul : " + mulRetionals.ToString());
            //dec
            decRetionals = oneRetionls - twoRetionals;
            Console.WriteLine("after dec : " + decRetionals.ToString());
            //div
            divRetionals = oneRetionls / twoRetionals;
            Console.WriteLine("after div : " + divRetionals.ToString());

            Console.WriteLine("Make raduce...");
            //redu
            oneRetionls.Reduce();
            twoRetionals.Reduce();
            Console.WriteLine("Make Casting...");


            Retionals foo = 123; // (1) an explicit casting can be used instead

            Retionals bar = (Retionals)42; // (2) an implicit casting can be used instead

            double baz = foo + bar; // the same as (1)

            double baz2 = (double)(foo - bar); // the same as (2)


            Console.WriteLine("(Retionals foo = 123) : {0}", foo);
            Console.WriteLine("(Retionals bar = (Retionals)42) : {0}", bar);
            Console.WriteLine("(double baz = foo + bar) : {0}", baz);
            Console.WriteLine("(double baz2 = (double)(foo - bar);) : {0}", baz2);

            Console.WriteLine("equal ? " + oneRetionls.Equals(twoRetionals));




        }
    }
}
