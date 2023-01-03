using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day4
    {
        //static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day4Input.txt");
        static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\TestKrister.txt");
        public static void Run()
        {
            Part1();
            
        }

        public static void Part1()
        {
            int sum = 0;
            foreach (string s in text)
            {
                string[] pair = s.Split(',');
                string[] first = pair[0].Split("-");
                string[] second = pair[1].Split("-");

                int.TryParse(first[0], out int a);
                int.TryParse(first[1], out int b);
                int.TryParse(second[0], out int c);
                int.TryParse(second[1], out int d);
                if (a <= c && b >= d || c <= a && d >= b) {
                    sum++;
                    //Console.WriteLine(first[0] + " : " + second[0] + "." + second[1] + " : " + first[1]);
                }
            }
          
            Console.WriteLine(sum);
        }

        public static void Part2()
        {

            int sum = 0;
            foreach (string s in text)
            {
                string[] pair = s.Split(',');
                string[] first = pair[0].Split("-");
                string[] second = pair[1].Split("-");

                int.TryParse(first[0], out int a);
                int.TryParse(first[1], out int b);
                int.TryParse(second[0], out int c);
                int.TryParse(second[1], out int d);
                if (   a <= d && a >= c
                    || b <= d && b >= c
                    || c <= b && c >= a
                    || d <= b && d >= a)
                {
                    // 905
                    sum++;
                    //Console.WriteLine(first[0] + " : " + second[0] + "." + second[1] + " : " + first[1]);
                }
            }

            Console.WriteLine(sum);
        }
    }
}

/*     
    {
        static string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day4Input.txt");
        public static void Run()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            
          
            Console.WriteLine();
        }

        public static void Part2()
        {
           
            Console.WriteLine();
        }
    }
 */