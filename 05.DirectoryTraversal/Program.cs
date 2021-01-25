using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DurectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> files = new Dictionary<string, Dictionary<string, decimal>>();

            DirectoryInfo info = new DirectoryInfo("../../../../03.MatchingWords");
            FileInfo[] directoryFiles = info.GetFiles();

            foreach (var item in directoryFiles)
            {
                if (files.ContainsKey(item.Extension))
                {
                    files[item.Extension].Add(item.Name, (decimal)(item.Length * 0.001));
                }
                else
                {
                    files.Add(item.Extension, new Dictionary<string, decimal>());
                    files[item.Extension].Add(item.Name, (decimal)(item.Length * 0.001));
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in files.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(item.Key);
                foreach (var file in item.Value.OrderByDescending(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value}kb");
                }
            }

            using (FileStream filer = new FileStream("../../../../../../../Desktop/report.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                
            }
            using (StreamWriter writer = new StreamWriter("../../../../../../../Desktop/report.txt"))
            {
                writer.WriteLine(sb.ToString());
            }
        }
    }
}
