using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            HashSet<string> wordsAdd = new HashSet<string>();

            using (StreamReader reader = new StreamReader(@"../../../words.txt"))
            {
                string currWord = reader.ReadLine();

                while (currWord != null)
                {
                    words.Add(currWord, 0);
                    wordsAdd.Add(currWord);
                    currWord = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(@"../../../text.txt"))
            {
                string curr = reader.ReadLine();
                while (curr != null)
                {
                    string arr = curr;
                    string currWord = String.Empty;
                    foreach (char item in arr)
                    {
                        if (item == 32 || item == 33 || item == 46 || item == 63)
                        {
                            if (words.ContainsKey(currWord))
                            {
                                words[currWord]++;
                            }
                            currWord = String.Empty;
                        }
                        else
                        {
                            if (Char.ToLower(item) >= 97 && Char.ToLower(item) <= 122)
                            {
                                currWord += Char.ToLower(item);
                            }
                        }
                    }
                    curr = reader.ReadLine();
                }
            }

            StringBuilder sb1 = new StringBuilder();

            foreach (var item in words)
            {
                sb1.AppendLine($"{item.Key} - {item.Value}");
            }

            File.WriteAllText(@"../../../actualResult.txt", sb1.ToString());
            sb1.Clear();

            foreach (var item in words.OrderByDescending(x => x.Value))
            {
                sb1.AppendLine($"{item.Key} - {item.Value}");
            }
            File.WriteAllText(@"../../../expectedResult.txt", sb1.ToString());
        }
    }
}
