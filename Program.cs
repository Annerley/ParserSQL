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
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                Parser a;
                string row;

                string columns_str = reader.ReadLine();
                string[] columns = columns_str.Split(";");
                int i = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    tmp = row.Split(';');
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        csv_string[columns[j]] = tmp[j];

                        Console.WriteLine(columns[j] + " " + tmp[j]);
                    }
                    csv_strings[i] = csv_string;

                    i++;
                }
                    Console.WriteLine("!"); 
                
            }

         
            
           
            
            
        }
    }
}
