using System;
using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    public class FileReader
    {
        public List<string> ReadFileToList(string fileName)
        {
            var listOfLines = new List<string>();
            try
            {
                using (StreamReader st = new StreamReader(fileName))
                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        listOfLines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be open.\nMessage: {0}", e.Message);
            }
            return listOfLines;
        }
    }
}
