using System;
using System.IO;
using System.Collections.Generic;


namespace ParserSQL
{
    class Program
    {
        static void Main(string[] args)
        {

            Parser db = new Parser();
            string[][] table = db.readTable("sql.csv");

            db.printTable(table);

            //пример select *название столбца* from *таблица только одна* where *мат. условие в одном из столбцов*
            











        }
    }
}
