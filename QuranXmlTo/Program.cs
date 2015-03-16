using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuranXmlTo.Core;

namespace QuranXmlTo
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new QuranParser("Source/quran-simple.xml");
            var quran = parser.Parse();
        }
    }
}
