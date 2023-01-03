using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
    internal class Day7
    {
        static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\Day6Input.txt");
        //static string[] text = File.ReadAllLines(@"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\Advent\TestKrister.txt");
        public static void Run()
        {
            Part1();
            //Part2();

        }
        public static void Part1()
        {
            
            Console.WriteLine();
        }
    }
}
/*
 * filstørrelse i directoriet
 * liste med folders i directoriet
 * sum av alle filene innover
 * 
 * public class FileDirectory{
            FileDirectory? parent;
            public string NameOnDirectory;
            public int SumFilesInFolder = 0;
            public int TotalSumInDirectory = 0;
            public List<FileDirectory> NestedDirectory = new List<FileDirectory>();

            public FileDirectory(string name)
            {
                NameOnDirectory = name;
                this.parent = null;
            }

            public FileDirectory(string name, FileDirectory parent)
            {
                NameOnDirectory = name;
                this.parent = parent;
            }


        }

 * List<FileDirectory> list = new List<FileDirectory>();
            int index = 0;
            foreach(string s in text)
            {
                string[] line = s.Split(' ');
                if (line.Length == 3)
                {
                    if (!line[2].Equals("..")) { 

                        list.Add(new FileDirectory(line[2]));
                    }
                }
                else
                {
                    if (int.TryParse(line[0], out int n))
                    {
                        list[index].SumFilesInFolder += n;
                    }
                    else
                    {
                        list[index].NestedDirectory.Add(new FileDirectory(line[1]));
                    }
                }
                
                
            }
 * 
 */