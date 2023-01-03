using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day3
    {
        public static void Run()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day3Input.txt");
            int sum = 0;
            foreach(string line in text)
            {
                char[] c = line.ToCharArray();
                bool found = false;
                int i = 0;
                while(i < c.Length / 2 && !found)
                {
                    for(int j = c.Length-1; j >= c.Length/2; j--)
                    {
                        if (c[i] == c[j])
                        {
                            int tmp = Convert.ToInt32(c[i] - 64);
                            if (tmp > 26)
                            {
                                sum += tmp - 32;
                            } else sum += tmp+26;
                            found = true;
                            break;
                        }
                    }
                    i++;
                }
            }
            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day3Input.txt");
            int sum = 0;
           for(int i = 0; i < text.Length; i+= 3)
            {
                char[] characker = text[i].ToCharArray();
                foreach (char c in characker)
                {
                    if (text[i + 1].Contains(c) && text[i+2].Contains(c))
                    {
                        int tmp = Convert.ToInt32(c)-64;
                        sum += tmp > 26 ? tmp -32: tmp+26;
                        //Console.WriteLine(c);
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
