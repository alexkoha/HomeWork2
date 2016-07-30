using System;
using System.Reflection;

namespace AttribDemo
{
    [CodeReview("Alex", "6/7/2016" , true)]
    public class A
    {
        
    }

    [CodeReview("Avi", "3/5/2014", true)]
    public class B
    {

    }

    [CodeReview("Almog", "25/3/2016", false)]
    public class C
    {

    }

    /**
Unless specified, the AttributeUsage attribute disallows decorating the same target more than once
It was a requirement that multiple attribute instances would be allowed to decorate a single target
Consider :
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
*/
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class CodeReviewAttribute : Attribute
    {
        private string _name;
        private string _date;
        private bool _approved;

        public string Name => _name;
        public string Date => _date;
        public bool Approved => _approved;

        public CodeReviewAttribute(string name, string date, bool approve)
        {
            _name = name;
            _date = date;
            _approved = approve;
        }
    }
    class Program
    {
        static bool AnalayzeAssembly(Assembly a)
        {
            bool isAllApproved = true;
            foreach (var type in a.GetTypes())
            {
                if (type.IsDefined(typeof(CodeReviewAttribute)))
                {
                    var temp = (CodeReviewAttribute)type.GetCustomAttribute(typeof(CodeReviewAttribute));
                    Console.WriteLine("{0} \t {1} \t {2}",temp.Name, temp.Date , temp.Approved);
                    // note that you are using a bitwise operator '&' instead of boolean '&&'
                    isAllApproved = isAllApproved & temp.Approved;
                }
            }
            return isAllApproved;
        }

        static void Main()
        {
            Console.WriteLine("Did all Approved ? " + AnalayzeAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
