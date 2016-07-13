using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class LookForFiles
    {
        public Dictionary<string,long> SearchFiles(string path, string pattern)
        {
            Dictionary<string, long> tempDic = new Dictionary<string, long>();
            var dir = new DirectoryInfo(path);
            FileInfo[] myFiles = dir.GetFiles();
            
            foreach (var file in myFiles)
            {
                using (StreamReader filePr = new StreamReader(file.FullName))
                {
                    string line;
                    while ((line = filePr.ReadLine()) != null)
                    {
                        if (line.Contains(pattern))
                        {
                            tempDic.Add(file.Name, file.Length);
                            break;
                        }
                    }
                }
            }
            return tempDic;
        }
    }
}
