using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class day6
    {
        static public void part1()
        {
            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day6.txt");
            string answer = "";
            for (int j = 0; j < 8; j++)
            {
                string col = "";
                for (int i = j; i < input.Length; i += 10)
                {
                    col += input[i];
                }
                var key = col.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).OrderByDescending(x => x.Count).Take(1).Select(x => x.Key).ToArray();
                answer += key[0];
            }
            Console.WriteLine(answer);
        }

        static public void part2()
        {
            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day6.txt");
            string answer = "";
            for (int j = 0; j < 8; j++)
            {
                string col = "";
                for (int i = j; i < input.Length; i += 10)
                {
                    col += input[i];
                }
                var key = col.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).OrderBy(x => x.Count).Take(1).Select(x => x.Key).ToArray();
                answer += key[0];
            }
            Console.WriteLine(answer);
        }
    }
}
