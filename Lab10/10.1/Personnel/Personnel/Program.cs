using System;

using System.Linq;

namespace Personnel
{
    class Program
    {
        static void Main()
        {
            string fileName = "people.txt";
            FileReader file = new FileReader();
            var listOf = file.ReadFileToList(fileName);
            if (listOf != null && listOf.Any())
            {
                Console.WriteLine("Text from file :");
                Console.WriteLine("----------------");
                foreach (var line in listOf)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File is empty.");
            }
        }
    }
}
