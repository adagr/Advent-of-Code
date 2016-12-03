using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class Day2
    {
        static public void day2Part1()
        {
            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day2.txt");
            string[] instructions = input.Split('\n');
            int n = 5;
            foreach (string instruction in instructions)
            {
                for(int i=0;i<instruction.Length;i++)
                {
                    if (instruction[i] == 'U')
                        n -= (n > 3) ? 3 : 0;
                    else if (instruction[i] == 'D')
                        n += (n < 7) ? 3 : 0;
                    else if (instruction[i] == 'L')
                        n -= (n % 3 == 1) ? 0 : 1;
                    else if (instruction[i] == 'R')
                        n += (n % 3 == 0) ? 0 : 1;
                }
                Console.Write(n);
            }
            Console.WriteLine("");
        }

        static public void day2Part2()
        {
            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day2.txt");
            string[] instructions = input.Split('\n');
            float n = 5, row = 3, col = 1;
            foreach (string instruction in instructions)
            {
                for (int i = 0; i < instruction.Length; i++)
                {
                    if (instruction[i] == 'U')
                    {
                        if (((row == 2 || row == 5) && col == 3))
                        {
                            n -= 2;
                            row--;
                        }
                        else if ((row == 3 || row == 4) && (col > 1 && col < 5))
                        {
                            n -= 4;
                            row--;
                        }
                    }
                    else if (instruction[i] == 'D')
                    {
                        if (((row == 1 || row == 4) && col == 3))
                        {
                            n += 2;
                            row++;
                        }
                        else if ((row == 2 || row == 3) && (col > 1 && col < 5))
                        {
                            n += 4;
                            row++;
                        }
                    }
                    else if (instruction[i] == 'L')
                    {
                        if ((130 / n) % 1 != 0)
                        {
                            n -= 1;
                            col--;
                        }
                    }
                    else if (instruction[i] == 'R')
                    {
                        if (col == 1 || col == 2 || (col == 3 && (row > 1 && row < 5)) || (col == 4 && row == 3))
                        {
                            n += 1;
                            col++;
                        }
                    }
                }
                Console.Write(n+" ");
            }
            Console.WriteLine("");
        }
    }
}
