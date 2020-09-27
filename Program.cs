using System;
using System.IO;
using System.Collections.Generic;

namespace currencyDevil
{
    class Program
    {
        static void Main(string[] args)
        {
            Processing(ChekFile());
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
        static void Processing(StreamReader file)
        {
            string start, finish, next;
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
           
            foreach (var item in scan)
            {
                Console.WriteLine(item);
            }

        }

    }
}
