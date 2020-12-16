using System;
using System.IO;
using System.Collections.Generic;


namespace ParserSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tmp;
            string path = "../../../sql.csv";

            Dictionary<int, Dictionary<string,string>> csv_strings = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<string, string> csv_string = new Dictionary<string, string>();

            
            int rows = 0, cols = 0;
            
            
            using (StreamReader reader = new StreamReader(path))
            {
                
                string row;

                string columns_str = reader.ReadLine();
                string[] columns = columns_str.Split(";");
                int i = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    tmp = row.Split(';');
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        if (j > cols) cols = j;
                    }
                    i++;
                    if (i > rows) rows = i;
                }
                    Console.WriteLine("!"); 
                
            }
            rows++;
            cols++;
            string[][] m = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                m[i] = new string[cols];
            }

            
            
            using (StreamReader reader = new StreamReader(path))
            {

                string row;

                //string columns_str = reader.ReadLine();
                //string[] columns = columns_str.Split(";");
                int i = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    tmp = row.Split(';');
                    for (int j = 0; j < tmp.Length; j++)
                    {
                       
                        m[i][j] = tmp[j];
                    }
                    i++;
                }
                Console.WriteLine("!");

            }


            //получение данных из csv файла
            //m[0][0-n] - названия столбцов
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine(m[i][j]);
                }
            }

            //пример select *название столбца* from *таблица только одна* where *мат. условие в одном из столбцов*
            











        }
    }
}
