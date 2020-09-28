using System;
using System.IO;
using System.Collections.Generic;

namespace currencyDevil
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveFile(searchingPuth(Processing(ChekFile())));
        }
        static void SaveFile(string result)
        {
            using (StreamWriter file2 = new StreamWriter("output.txt", true))
            {
                file2.Write(result);
            }
        }
        static StreamReader ChekFile()
        {
            try
            {
                StreamReader file = new StreamReader("input.txt");

                return file;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Данных нет!");
                Console.ResetColor();
                Console.WriteLine("Зайдите в директорию программы, и заполнитей файл \"input.txt\"");
                using (StreamWriter file = new StreamWriter("input.txt"))
                {
                    Console.WriteLine("файл создан");
                }
                return null;
            }
        }
        static List<string> Processing(StreamReader file)
        {
            int x = -1;
            List<string> scan = new List<string>();

            foreach (var item in file.ReadLine())
            {
                x++;
            }
            StreamReader file2 = new StreamReader("input.txt");
            for (int i = 0; i < x; i++)
            {
                scan.Add(file2.ReadLine());
            }            
         
            return scan;

        }
        static string searchingPuth(List<string> list)
        {
            int x = list.Count - 2;
            string[] sardina = new string[list.Count];
            bool check = false;
            string[,] map = new string[x, 2];
            int id = 0;

            foreach (var item in list)
            {
                sardina[id] = item;
                id++;
            }
            var firstPosition = new { Start = sardina[0].Split(' ')[0], Finish = sardina[0].Split(' ')[1] };
            string selector = firstPosition.Start;
            string result = firstPosition.Start + " ";

            for (int i = 0; i < sardina.Length-2; i++)
            {               
                map[i, 0] = sardina[i+2].Split(' ')[0];
                map[i, 1] = sardina[i+2].Split(' ')[1];
            }

            do
            {
                for (int i = 0; i < x; i++)
                {
                    check = false;

                    if (selector == map[i, 0])
                    {
                        selector = map[i, 1];
                        result += selector+ " " ;
                        check = true;
                    }
                }

            } while (check);
            return result;
        }

    }
}
