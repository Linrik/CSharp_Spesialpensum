using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day5
    {
        static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day5Input.txt");
        //static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\TestKrister.txt");
        public static void Run()
        {
            Part1();
            Part2();

        }

        public static void Part1()
        {
            List<Stack<char>> stack = new List<Stack<char>>();
            
            int index = 1;
            for (int i = 0; i < 9; i++)
            {
                stack.Add(new Stack<char>());
                for(int j = 7; j >= 0; j--)
                {
                    string line = text[j];
                    if (Char.IsLetter(line[index]))
                    {
                        stack[i].Push(line[index]);
                    }
                    else break;
                }
                index += 4;
                
            }

            for (int i = 10; i < text.Length; i++)
            {
                string[] operation = text[i].Split(' ');
                int moves = Convert.ToInt32(operation[1]);
                int from = Convert.ToInt32(operation[3]) - 1;
                int to = Convert.ToInt32(operation[5]) - 1;
                for (int j = 0; j < moves; j++)
                {
                    stack[to].Push(stack[from].Pop());
                }
            }
            string s = "";
            foreach(Stack<char> sc in stack)
            {
               s += sc.Peek();
            }

            Console.WriteLine(s);
        }

        public static void Part2()
        {
            List<Stack<char>> stack = new List<Stack<char>>();

            int index = 1;
            for (int i = 0; i < 9; i++)
            {
                stack.Add(new Stack<char>());
                for (int j = 7; j >= 0; j--)
                {
                    string line = text[j];
                    if (Char.IsLetter(line[index]))
                    {
                        stack[i].Push(line[index]);
                    }
                    else break;
                }
                index += 4;

            }
            for (int i = 10; i < text.Length; i++)
            {
                string[] operation = text[i].Split(' ');
                char[] moves = new char[Convert.ToInt32(operation[1])];
                int from = Convert.ToInt32(operation[3]) - 1;
                int to = Convert.ToInt32(operation[5]) - 1;
                for (int j = 0; j < moves.Length; j++)
                {
                    moves[j] = stack[from].Pop();
                }
                for (int j = moves.Length - 1; j >= 0; j--)
                {
                    stack[to].Push(moves[j]);
                }
            }
            

            string s = "";
            foreach (Stack<char> sc in stack)
            {
                s += sc.Peek();
            }

            Console.WriteLine(s);
        }

    }
}
