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

            Dictionary<int, Dictionary<string,string>> strings = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<string, string> values = new Dictionary<string, string>();



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
                        values[columns[j]] =  tmp[j];
                        
                        Console.WriteLine(columns[j] + " " + tmp[j]);
                    }
                    strings[i] = values;

                    i++;
                    Console.WriteLine("!");
                   
                    
                }
            }

         
            
           
            
            
        }
    }
}
