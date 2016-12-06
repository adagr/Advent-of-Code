using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class day4
    {
        static public void part1()
        {
            string[] input = System.IO.File.ReadAllLines(@"J:\Projects\advent of code\advent of code\Input\day4.txt");
            int sum = 0;
            foreach (string instruction in input)
            {
                string checksum = instruction.Substring(instruction.Length - 6).Substring(0, 5);
                char[] name = instruction.Substring(0, instruction.Length - 11).Replace("-", string.Empty).ToCharArray();
                int id = Convert.ToInt32(instruction.Substring(instruction.Length - 10).Substring(0, 3));
                Dictionary<char, int> letters = new Dictionary<char, int>();

                //Count letters
                foreach(char c in name)
                {
                    if (letters.ContainsKey(c))
                        letters[c] += 1;
                    else
                        letters.Add(c, 1);
                }
                
                //Sort alphabetically and by frequency
                var list = letters.ToList();
                list = list.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

                //Check if checksum is correct
                string common = "";
                for (int i=0;i<5;i++)
                    common += list[i].Key;
                if (common == checksum)
                    sum += id;
            }
            Console.WriteLine(sum);
        }

        static public void part2()
        {
            string[] input = System.IO.File.ReadAllLines(@"J:\Projects\advent of code\advent of code\Input\day4.txt");
            foreach (string instruction in input)
            {
                string[] names = instruction.Substring(0, instruction.Length - 11).Split('-');
                int id = Convert.ToInt32(instruction.Substring(instruction.Length - 10).Substring(0, 3));
                int increment = id % 26;
                List<string> words = new List<string>();
                foreach(string name in names)
                {
                    string word = "";
                    foreach(char c in name)
                    {
                        int i = (int)c + increment;
                        word += (i>122)?Convert.ToChar(i-26): Convert.ToChar(i);
                    }
                    words.Add(word);
                }
                if (words.Contains("northpole"))
                {
                    Console.WriteLine(id);
                    break;
                }
            }
        }
    }
}
