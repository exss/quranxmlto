using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuranXmlTo.Core;
using QuranXmlTo.Formatter;

namespace QuranXmlTo
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new QuranParser("Source/quran-simple.xml");
            var quran = parser.Parse();
            var csvFormatter = new CsvQuranFormatter("CSV");
            csvFormatter.Format(quran);
        }
    }
}
