using System;
using System.IO;
using System.Text;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../text.txt"))
            {
                string path = @"../../../output.txt";
                string line = reader.ReadLine();
                int counter = 1;

                StringBuilder sb = new StringBuilder();

                while (line != null)
                {

                    int letters = 0;
                    int marks = 0;

                    foreach (char item in line)
                    {
                        if (item != 32)
                        {
                            if ((item >= 65 && item <= 90) || (item >= 96 && item <= 122))
                            {
                                letters++;
                            }
                            else
                            {
                                marks++;
                            }
                        }
                    }

                    sb.AppendLine($"Line {counter}: {line} ({letters})({marks})");

                    counter++;
                    line = reader.ReadLine();

                }

                File.WriteAllText(path, sb.ToString());
            }
        }
    }
}
