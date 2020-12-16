using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
/*
namespace ParserSQL
{
    class Parser
    {
        public void getStrings(StreamReader reader)
        {
            string row;

            string columns_str = reader.ReadLine();
            string[] columns = columns_str.Split(";");
            int i = 0;
            while ((row = reader.ReadLine()) != null)
            {
                parseString(row);
            }
            
        }
        public void parseString(string row)
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
        
    }
}*/
