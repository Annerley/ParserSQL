using System;
using System.Collections.Generic;
using System.Text;

namespace ParserSQL
{
    interface ParserInterface
    {
        string[][] readTheTable(string tableName);


        string[] select(string[] cols);
        void where();
    }
}
