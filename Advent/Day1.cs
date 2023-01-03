using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day1
    {
        public static void Run()
        {
            Part2();
            Part3();
        }

        public static void Part1() {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Dag1Input.txt");
            int max = 0;
            int tmp = 0;
            foreach (string line in text)
            {
                if (int.TryParse(line, out int i))
                {
                    tmp += i;
                }
                else
                {
                    if (tmp > max) max = tmp;
                    tmp = 0;
                }
            }
            Console.WriteLine(max);
        }

        public static void Part2()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Dag1Input.txt");
            int max1 = 0;
            int max2 = 0;
            int max3 = 0;
            int tmp = 0;
            foreach (string line in text)
            {
                if (int.TryParse(line, out int i))
                {
                    tmp += i;
                }
                else
                {
                    if (tmp > max1)
                    {
                        max3 = max2;
                        max2 = max1;
                        max1 = tmp;
                    } else if (tmp > max2)
                    {
                        max3 = max2;
                        max2 = tmp;
                    }else if (tmp > max3)
                    {
                        max3 = tmp;
                    }  
                    tmp = 0;
                }
            }
            Console.WriteLine(max1+max2+max3);
        }
        public static void Part3()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Dag1Input.txt");
            int[] list = new int[4];
            foreach (string line in text)
            {
                if (int.TryParse(line, out int i))
                {
                    list[0] += i;
                }
                else
                {
                    Array.Sort(list);
                    list[0] = 0;
                }
            }
            Console.WriteLine(list[3] + list[2] + list[1]);
        }
    }
}
