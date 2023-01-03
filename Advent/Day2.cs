using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day2
    {
        public static void Run()
        {
            part2();
        }
        static void part1()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day2Input.txt");
            int draw = 3;
            int win = 6;
            int points = 0;

            foreach(string line in text)
            {
                string[] game = line.Split(' ');
                int player1 = Convert.ToInt32(game[0].ToCharArray()[0]-64);
                int player2 = Convert.ToInt32(game[1].ToCharArray()[0]-87);

                if (player1 == player2) points += draw;
                if (player1 == 1 && player2 == 2 || player1 == 2 && player2 == 3 || player1 == 3 && player2 == 1) {
                    points += win;
                }
                points += player2;
                
            }
            Console.WriteLine(points);

        }

        static void part2()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day2Input.txt");
            int draw = 3;
            int win = 6;
            int points = 0;

            foreach (string line in text)
            {
                string[] game = line.Split(' ');
                int player1 = Convert.ToInt32(game[0].ToCharArray()[0] - 64);
                char player2 = game[1].ToCharArray()[0];

                switch (player2)
                {
                    case 'X':
                        points += findNumber(player1, false);
                        break;
                    case 'Y':
                        points += player1 + draw;
                        break;
                    case 'Z':
                        points += win + findNumber(player1, true);
                        break;

                }

            }
            Console.WriteLine(points);
        }

        public static int findNumber(int player1, bool win)
        {
            int point = 0;
            switch(player1)
            {
                case 1:
                    point = win ? 2:3;
                    break;
                case 2:
                    point = win ? 3:1;
                    break; 
                case 3:
                    point = win ? 1:2;
                    break;
            }
                return point;
        }
    }
}
