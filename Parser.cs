using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ParserSQL
{
    class Parser
    {
        
        public string[][] readTable(string tableName)
        {

            string[] tmp;
            string path = "../../../" + tableName;

            Dictionary<int, Dictionary<string,string>> csv_strings = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<string, string> csv_string = new Dictionary<string, string>();
            int rows = 0, cols = 0;
          
            //считываем количество данных для задания матрицы
            using (StreamReader reader = new StreamReader(path))
            {
                string row;
                int i = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    tmp = row.Split(';');
                    for (int j = 0; j <= tmp.Length; j++)
                    {
                        if (j > cols) cols = j;
                    }
                    i++;
                    if (i > rows) rows = i;
                }
                    Console.WriteLine("!"); 
                
            }
            //создаем матрицу
            string[][] m = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                m[i] = new string[cols];
            }
            this.rows = rows;
            this.cols = cols;
            
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            //записываем данные в матрицу
            using (StreamReader reader = new StreamReader(path))
            {

                string row;
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
          
            return m;
        }

        public void printTable(string[][] a)
        {
            for (int i = 0; i < this.cols; i++)
            {
                for (int j = 0; j < this.rows; j++)
                {
                    Console.Write(a[i][j]+" ");
                }
                Console.WriteLine();
            }
        }


        //string[] select(string[] cols);
        //void where();



        public int rows;
        public void setRows(int rows)
        {
            this.rows = rows;
        }
        public int getRows()
        {
            return rows;
        }




        public int cols;

        public void setCols(int cols)
        {
            this.cols = cols;
        }

    }
}
