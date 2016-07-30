using System;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
              
                if (args.Length == 2)
                {
                    LookForFiles newSearch = new LookForFiles();

                    var list = newSearch.SearchFiles(args[0], args[1]);

                    if (list.Count == 0)
                    {
                        Console.WriteLine("None files found!");
                    }
                    else
                    {
                        Console.WriteLine("File Name".PadRight(40) + "Lenght");
                        Console.WriteLine("".PadRight(50, '-'));
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.Key.PadRight(30)}\t \t{item.Value}");
                        }
                    }
                }
                else Console.WriteLine("Somthing wrong.Try again....");
            }
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e);
            }
        }
    }
}
