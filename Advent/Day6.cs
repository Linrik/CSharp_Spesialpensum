using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day6
    {
        static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day6Input.txt");
        //static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\TestKrister.txt");
        public static void Run()
        {
            //Part1();
            Part2();

        }
        public static void Part1()
        {
            string txt = text[0];
            bool found = false;
            int index = 0;
            int marker = index + 4;

            while(!found && index < txt.Length)
            {
                char[] sequense = { txt[index], txt[index + 1], txt[index + 2], txt[index + 3] };
                bool duplicate = false;
                for (int i = 0; i < sequense.Length; i++)
                {
                    for(int j = i+1; j < sequense.Length; j++)
                    {
                        Console.WriteLine(sequense[i] == sequense[j]);
                        if (sequense[i] == sequense[j]) {
                            duplicate = true;
                            break;
                        }
                    }
                }
                if (!duplicate)
                {
                    found = true;
                    marker = index + 4;
                    break;
                }
                index++;
            }

            Console.WriteLine(marker);
        }
        public static void Part2()
        {
            string txt = text[0];
            bool found = false;
            int index = 0;
            int marker = 0;

            while (!found && index < txt.Length)
            {
                string sequense = "" + txt[index];
                bool duplicate = false;
                for (int i = index+1; i < index+14; i++)
                {
                    if (i < txt.Length - 14)
                    {
                        if (sequense.Contains(txt[i]))
                        {
                            duplicate = true;
                            break;
                        }
                        else sequense += "" + txt[i];
                    }
                }
                Console.WriteLine(sequense);

                if (!duplicate)
                {
                    found = true;
                    marker = index + 14;
                    break;
                }
                index++;
            }
            Console.WriteLine(marker);
        }
    }
}
