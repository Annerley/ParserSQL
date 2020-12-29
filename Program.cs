using System;
using System.IO;
using System.Collections.Generic;


namespace ParserSQL
{
    class Program
    {
        static int Main(string[] args)
        {
            //примеры запросов
            //SELECT name FROM sql.csv WHERE surname = mines;
            //SELECT id FROM sql.csv WHERE age > 13;
            //SELECT name FROM data.csv WHERE id_dept = 201;
            Parser db = new Parser();
            string request = Console.ReadLine();
            if(request == "/q" || request == "/quit")
            {
                return 0;
            }
            db.parse(request);
            db.readTable(db.csv);
            db.printTable();
            //пример select *название столбца* from *таблица только одна* where *мат. условие в одном из столбцов*

            db.where(db.condition);







            return 0;


        }
    }
}
