using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class Day1
    {

        enum Heading { North, West, South, East };
        static int y = 0, x = 0;

        static bool intersects(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            bool l1vert = p1[0] == p2[0];
            bool l1horiz = p1[1] == p2[1];
            bool l2vert = p3[0] == p4[0];
            bool l2horiz = p3[1] == p4[1];

            if (l1vert && l2vert || l1horiz && l2horiz)
            {
                return false;
            }

            int lx = 0;
            int ly = 1;
            if (l1vert)
            {
                lx = 1;
                ly = 0;
            }

            if (p1[lx] < p3[lx] && p2[lx] > p3[lx] && p1[ly] > p3[ly] && p1[ly] < p4[ly])
            {
                x = p3[lx];
                y = p1[ly];
                return true;
            }

            if (p2[lx] < p3[lx] && p1[lx] > p3[lx] && p1[ly] > p3[ly] && p1[ly] < p4[ly])
            {
                x = p3[lx];
                y = p1[ly];
                return true;
            }

            if (p1[lx] < p3[lx] && p2[lx] > p3[lx] && p1[ly] > p4[ly] && p1[ly] < p3[ly])
            {
                x = p3[lx];
                y = p1[ly];
                return true;
            }

            if (p2[lx] < p3[lx] && p1[lx] > p3[lx] && p1[ly] > p4[ly] && p1[ly] < p3[ly])
            {
                x = p3[lx];
                y = p1[ly];
                return true;
            }

            return false;
            /*int A1 = p2[0] - p1[0];
            int B1 = p2[1] - p1[1];
            int A2 = p4[0] - p3[0];
            int B2 = p4[1] - p3[1];

            float delta = B1 * A2 - A1 * B2;
            if (delta == 0)
                return false;
            if (A1 == 0 && B1 > 0)
            {
                if (p3[1] < p2[1] && p3[1] > p1[1])
                {
                    if (A2 > 0)
                    {
                        if (p1[0] < p4[0] && p1[0] > p3[0]) {
                            x = p1[0];
                            y = p3[1];
                            return true;
                        }
                    } else
                    {
                        if (p1[0] > p4[0] && p1[0] < p3[0])
                        {
                            x = p1[0];
                            y = p3[1];
                            return true;
                        }
                    }
                }
            } else if (A1 == 0 && B1 < 0)
            {
                if (p3[1] < p1[1] && p3[1] > p2[1])
                {
                    if (A2 > 0)
                    {
                        if (p2[0] < p4[0] && p2[0] > p3[0]) {
                            x = p1[0];
                            y = p3[1];
                            return true;
                        }
                    }
                    else
                    {
                        if (p2[0] > p4[0] && p2[0] < p3[0])
                        {
                            x = p1[0];
                            y = p3[1];
                            return true;
                        }
                    }
                }
            } else if (B1 == 0 && A1 > 0)
            {
                if (p3[0] < p2[0] && p3[0] > p1[0])
                {
                    if (B2 > 0)
                    {
                        if (p1[1] < p4[1] && p1[1] > p3[1])
                        {
                            x = p3[0];
                            y = p1[1];
                            return true;
                        }
                    } else
                    {
                        if (p1[1] > p4[1] && p1[1] < p3[1])
                        {
                            x = p3[0];
                            y = p1[1];
                            return true;
                        }
                    }
                }
            }
            else if (B1 == 0 && A1 < 0)
            {
                if (p3[0] < p1[0] && p3[0] > p2[0])
                {
                    if (B2 > 0)
                    {
                        if (p2[1] < p4[1] && p2[1] > p3[1])
                        {
                            x = p3[0];
                            y = p1[1];
                            return true;
                        }
                    }
                    else
                    {
                        if (p2[1] > p4[1] && p2[1] < p3[1])
                        {
                            x = p3[0];
                            y = p1[1];
                            return true;
                        }
                    }
                }
            }
            
            return false;*/
        }

        static public void day1()
        {
            int currentHeading = (int)Heading.North;
            List<int[]> locations = new List<int[]>();
            locations.Add(new int[2] { 0, 0 });
            bool foundGoal = false;

            string input = System.IO.File.ReadAllText(@"J:\Projects\advent of code\advent of code\Input\day1.txt");
            string[] separator = { ", " };
            StringSplitOptions options = new StringSplitOptions();
            string[] instructions = input.Split(separator,options);
            foreach (string s in instructions)
            {
                char turn = s[0];
                int steps = Int32.Parse(s.Substring(1));
                if (turn == 'L')
                {
                    currentHeading = (currentHeading + 1) % 4;
                }
                else
                {
                    currentHeading = (currentHeading - 1 + 4) % 4;
                }
                switch (currentHeading)
                {
                    case 0: y += steps; break;
                    case 1: x -= steps; break;
                    case 2: y -= steps; break;
                    case 3: x += steps; break;
                    default: Console.WriteLine("Wrong heading"); break;
                }                
                
                for (int i = 1; i < locations.Count-1; i++)
                {
                    if (i == locations.Count - 1)
                        return;
                    int[] l1 = locations[i - 1];
                    int[] l2 = locations[i];
                    int[] l3 = locations[locations.Count - 1];
                    int[] l4 = new int[2] { x, y };
                    if (intersects(l1, l2, l3, l4))
                    {
                        foundGoal = true;
                        break;
                    }
                }
                
                int[] location = new int[2] { x, y };
                Console.WriteLine(location[0] + " " + location[1]);
                if (foundGoal)
                    break;
                locations.Add(location);
            }
            int distance = Math.Abs(y) + Math.Abs(x);
            Console.WriteLine("");
            Console.WriteLine(y + " " + x);
            Console.WriteLine(distance);
        }

       
    }
}
