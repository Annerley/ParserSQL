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
            db.readTable("sql.csv");

            db.printTable();

            //пример select *название столбца* from *таблица только одна* where *мат. условие в одном из столбцов*

            db.where("name=lala");










        }
    }
}
