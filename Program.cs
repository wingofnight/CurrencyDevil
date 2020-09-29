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
            using (StreamWriter file2 = new StreamWriter("output.txt", false))
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
            int x = 0;
            List<string> scan = new List<string>();

            foreach (var item in file.ReadLine())
            {
                x++;
            }
            file.Close();
            StreamReader file2 = new StreamReader("input.txt");
            for (int i = 0; i <= x; i++)
            {
                scan.Add(file2.ReadLine());
            }
            
            return scan;

        }
        static string searchingPuth(List<string> list)
        {            
            string[] sardina = new string[list.Count];    
            int id = 0;

            foreach (var item in list)
            {
                sardina[id] = item;
                id++;
            }

            var firstPosition = new { Start = sardina[0].Split(' ')[0], Finish = sardina[0].Split(' ')[1] };
            
            string result = "";
           
            list.RemoveAt(0);
            list.RemoveAt(0);
            list.Sort();
            List<string> startList = new List<string>();
            List<string> newResult = new List<string>();
           
            foreach (var item in list)
            {
                if (item.Split(' ')[0] == firstPosition.Start)
                {
                    startList.Add(item);
                    if (item.Split(' ')[1] == firstPosition.Finish)
                    {
                        newResult.Add(item);
                    }                    
                }                
                Console.WriteLine(item);
            }

            List<string> buf = new List<string>();
            List<string> roundTwo = new List<string>();
           
            foreach (var item in startList)
            {
                list.Remove(item);
                Console.WriteLine();
                Console.WriteLine(item);

                foreach (var zitem in list)
                {
                    if (item.Split(' ')[1] == zitem.Split(' ')[0])
                    {
                        buf.Add(zitem);
                        Console.WriteLine("*"+zitem);
                        if (zitem.Split(' ')[1] == firstPosition.Finish)
                        {
                            newResult.Add(item + " " + zitem);
                        }
                        else
                        {
                            roundTwo.Add(item + " " + zitem);
                        }
                    }                    
                }
            }

            list = buf;
            foreach (var item in list)
            {              
                Console.WriteLine();
                Console.WriteLine("$"+item);
            }
            foreach (var item in newResult)
            {
                Console.WriteLine(item);
            }
            foreach (var item in roundTwo)
            {
                Console.WriteLine(item);
            }
            //2 шаг после этого шага, принцип обработки данных выведится в отдельную функцию.
           
            if (newResult.Count == 0)
            {
                roundTwo = list;
                foreach (var item in roundTwo)
                {
                    list.Remove(item);
                    Console.WriteLine();
                    Console.WriteLine(item);

                    foreach (var zitem in list)
                    {
                        if (item.Split(' ')[1] == zitem.Split(' ')[0])
                        {
                            buf.Add(zitem);
                            Console.WriteLine("*" + zitem);
                            if (zitem.Split(' ')[1] == firstPosition.Finish)
                            {
                                newResult.Add(item + " " + zitem);
                            }
                            else
                            {
                                roundTwo.Add(item + " " + zitem);
                            }
                        }
                    }
                }
            }
            return result;
        }

    }
}
