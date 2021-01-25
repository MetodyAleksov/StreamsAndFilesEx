using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.Evenlines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../text.txt"))
            {
                List<string> curr = reader.ReadLine().Split(" ").ToList();
                int counter = 0;
                while (curr != null)
                {
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < curr.Count; i++)
                        {
                            if (curr[i].Contains('-'))
                            {
                                curr[i] = curr[i].Replace('-', '@');
                            }
                            if (curr[i].Contains('.'))
                            {
                                curr[i] = curr[i].Replace('.', '@');
                            }
                            if (curr[i].Contains(','))
                            {
                                curr[i] = curr[i].Replace(',', '@');
                            }
                            if (curr[i].Contains('!'))
                            {
                                curr[i] = curr[i].Replace('!', '@');
                            }
                            if (curr[i].Contains('?'))
                            {
                                curr[i] = curr[i].Replace('?', '@');
                            }
                        }

                        curr.Reverse();
                        Console.WriteLine(string.Join(" ", curr));
                    }

                    curr = reader.ReadLine().Split().ToList();
                    counter++;
                }
            }
        }
    }
}
