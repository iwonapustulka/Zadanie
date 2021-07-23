using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace Zadanie
{
    sealed class Mapping :ClassMap<School>
    {
       public Mapping()
        {
            Map(m => m.LastName).Index(0);
            Map(m => m.FirstName).Index(1);
            Map(m => m.SSN).Index(2);
            Map(m => m.Test1).Index(3);
            Map(m => m.Test2).Index(4);
            Map(m => m.Test3).Index(5);
            Map(m => m.Test4).Index(6);
            Map(m => m.Final).Index(7);
            Map(m => m.Grade).Index(8);
        }
    }
}
