﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ParserSQL
{
    class Parser
    {

        public string[][] db;
        public int rows;
        public int cols;
        public string csv = null;
        public string table = null;
        public string condition = null;


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
                    //Console.WriteLine("!"); 
                
            }
            //создаем матрицу
            string[][] m = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                m[i] = new string[cols];
            }
            this.rows = rows;
            this.cols = cols;
            
            //Console.WriteLine(rows);
            //Console.WriteLine(cols);
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
                        tmp[j] = tmp[j].Trim(new char[] { '"' });
                        m[i][j] = tmp[j];
                    }
                    i++;
                }
                //Console.WriteLine("!");

            }


            //получение данных из csv файла
            //m[0][0-n] - названия столбцов
            db = m;
            return m;
        }

        public void printTable()
        {
            Console.WriteLine();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write(db[i][j]+" ");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void setRows(int rows)
        {
            this.rows = rows;
        }
        public int getRows()
        {
            return rows;
        }

        public void setCols(int cols)
        {
            this.cols = cols;
        }


        public int select(string stringName)
        {
            int row = Int32.MaxValue;
            for (int i = 0; i < cols; i++)
            {
                if(db[0][i]==stringName)
                {
                    row = i;
                }
            }
            if(row == Int32.MaxValue)
            {
                //exception
                Console.WriteLine("There is no table with this name ");
                return row;
            }
            for (int i = 1; i < rows; i++)
            {
                //Console.Write(db[i][row]+" ");
                //Console.WriteLine();
            }
            return row;
        }

        public void where(string condition)
        {
            string start;
            string end;
            //имя_столбца=’слово’

            //=
            if (condition.IndexOf('=')!=-1)
            {
                int i = condition.IndexOf('=');
                start = condition.Substring(0, i);
                end = condition.Substring(i+1);
                //Console.WriteLine("start = "+ start + " end = " + end);
                int row = select(start);
                for (int j = 1; j < rows; j++)
                {
                    if(db[j][row]== end)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            if(db[0][k]==table)
                            {
                                Console.Write(db[j][k] + " ");
                            }
                            
                           
                        }
                        Console.WriteLine();
                        
                    }
                }
                Console.WriteLine();

            }

            //>
            if (condition.IndexOf('>') != -1)
            {
                int i = condition.IndexOf('>');
                start = condition.Substring(0, i);
                end = condition.Substring(i + 1);
                //Console.WriteLine("start = " + start + " end = " + end);

                int row = select(start);
                for (int j = 1; j < rows; j++)
                {
                    if(Convert.ToInt32(db[j][row]) > Convert.ToInt32(end))
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            if (db[0][k] == table)
                            {
                                Console.Write(db[j][k] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }
          
            //
            if (condition.IndexOf('<') != -1)
            {
                int i = condition.IndexOf('<');
                start = condition.Substring(0, i);
                end = condition.Substring(i + 1);
                Console.WriteLine("start = " + start + " end = " + end);

                int row = select(start);
                for (int j = 1; j < rows; j++)
                {
                    if (Convert.ToInt32(db[j][row]) < Convert.ToInt32(end))
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            if (db[0][k] == table)
                            {
                                Console.Write(db[j][k] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }

            return;

            


        }

        public void parse(string request)
        {
            
            request = request.Trim(new char[] { ';' });
            string[] words = request.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                table = words[1];
                csv = words[3];
                //Console.WriteLine(words[i]);
                if(words[i] == "WHERE")
                {
                    condition = "";
                    for (int j = i + 1; j < words.Length; j++)
                    {
                        condition += words[j];
                    }
                    
                    break;
                }
            }
            

        }
    }
}
