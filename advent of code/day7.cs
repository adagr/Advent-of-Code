using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace advent_of_code
{
    class day7
    {
        static public void part1()
        {
            string[] input = System.IO.File.ReadAllLines(@"J:\Projects\advent of code\advent of code\Input\day7.txt");
            int count = 0;
            foreach(string line in input)
            {
                bool valid = true;
                MatchCollection brackets = Regex.Matches(line, @"\[\w+\]");
                foreach (Match m in brackets)
                {
                    if (hasABBA(m.ToString().Substring(1, m.Length - 1))) {
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                    continue;
                string[] words = Regex.Split(line, @"\[\w+\]");
                foreach (string word in words)
                {
                    if (hasABBA(word))
                    {
                        count++;
                        break;
                    }
                }
            }
            Console.WriteLine(count);
        }

        static bool hasABBA(string s)
        {
            for (int i = 0; i < s.Length - 3; i++)
            {
                if (s[i] != s[i + 1] && s[i] == s[i + 3] && s[i + 1] == s[i + 2])
                    return true;
            }
            return false;
        }

        static public void part2()
        {
            string[] input = System.IO.File.ReadAllLines(@"J:\Projects\advent of code\advent of code\Input\day7.txt");
            int count = 0;
            foreach (string line in input)
            {
                List<string> list = new List<string>();
                string[] words = Regex.Split(line, @"\[\w+\]");
                foreach (string word in words)
                {
                    list.AddRange(hasABA(word));
                }
                MatchCollection brackets = Regex.Matches(line, @"\[\w+\]");
                foreach (Match m in brackets)
                {
                    if (hasBAB(m.ToString().Substring(1, m.Length - 1), list))
                    {
                        count++;
                        break;
                    }
                }
            }
            Console.WriteLine(count);
        }

        static List<string> hasABA(string s)
        {
            List<string> aba = new List<string>();
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] != s[i + 1] && s[i] == s[i + 2])
                    aba.Add(""+s[i+1]+s[i]+s[i+1]);
            }
            return aba;
        }

        static bool hasBAB(string s, List<string> l)
        {
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (l.Contains(s.Substring(i, 3)))
                    return true;
            }
            return false;
        }
    }
}
