using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace advent_of_code
{
    class day3
    {
        static int count = 0;
        static public void day3Part1()
        {
            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day3.txt");
            string[] instructions = input.Split('\n');
            foreach (string instruction in instructions)
            {
                string[] inst = Regex.Split(instruction, @"\s+");
                int x = Int32.Parse(inst[1]);
                int y = Int32.Parse(inst[2]);
                int z = Int32.Parse(inst[3]);
                validTriangle(x, y, z);                    
            }
            Console.WriteLine(count);
        }

        static public void day3Part2()
        {
            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day3.txt");
            string[] instructions = input.Split('\n');
            for (int i = 0; i < instructions.Length; i += 3)
            {
                int[] x = new int[3];
                int[] y = new int[3];
                int[] z = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    string[] inst = Regex.Split(instructions[i + j], @"\s+");
                    x[j] = Int32.Parse(inst[1]);
                    y[j] = Int32.Parse(inst[2]);
                    z[j] = Int32.Parse(inst[3]);
                }
                validTriangle(x[0], x[1], x[2]);
                validTriangle(y[0], y[1], y[2]);
                validTriangle(z[0], z[1], z[2]);
            }
            Console.WriteLine(count);
        }

        static void validTriangle(int x, int y, int z)
        {
            if (x + y > z && x + z > y && y + z > x)
                count++;
        }
    }
}
