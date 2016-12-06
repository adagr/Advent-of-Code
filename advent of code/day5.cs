using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace advent_of_code
{
    class day5
    {
        static class RandomLetter
        {
            static Random _random = new Random();
            public static string GetLetter()
            {
                Int64 num = _random.Next(0, 16);
                return String.Format("{0:X}", num);
            }
        }

        static public void part1()
        {
            MD5 md5 = MD5.Create();
            int index = 0, count = 0;
            List<char> password = new List<char>();
            while (true)
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes("abbhdwsy" + index);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                string s = sb.ToString();
                if (s.Substring(0, 5) == "00000")
                {
                    count++;
                    password.Add(s[5]);
                }
                
                if (index % 10000 == 0)
                {
                    for (int i=0;i<8;i++)
                    {
                        if (i < count)
                            Console.Write(password[i]);
                        else
                            Console.Write(RandomLetter.GetLetter());
                    }
                    Console.Write("\r");
                }
                index++;
            }
        }

        static public void part2()
        {
            MD5 md5 = MD5.Create();
            int index = 0;
            char[] password = new char[8] { '-', '-', '-', '-', '-', '-', '-', '-' };
            while (true)
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes("abbhdwsy" + index);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                string s = sb.ToString();
                if (s.Substring(0, 5) == "00000")
                {
                    int pos;
                    if (Int32.TryParse(s[5].ToString(), out pos) && pos < 8 && password[pos] == '-')
                    {
                        password[pos] = s[6];
                    }
                }
                if (index % 10000 == 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (password[i] != '-')
                            Console.Write(password[i]);
                        else
                            Console.Write(RandomLetter.GetLetter());
                    }
                    Console.Write("\r");
                }
                index++;
            }
        }
    }
}
