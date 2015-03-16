using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using QuranXmlTo.Models;

namespace QuranXmlTo.Formatter
{
    /// <summary>
    /// Interface that defines a quran formatter. You may want
    /// to use QuranFormatter as your base class as it contains a method that invoke
    /// the formatter methods.
    /// </summary>
    public interface IQuranFormatter
    {
        /// <summary>
        /// Formats the specified quran.
        /// </summary>
        /// <param name="quran">The quran.</param>
        void Format(Quran quran);
        /// <summary>
        /// Formats the specified quran asynchronously.
        /// </summary>
        /// <param name="quran">The quran.</param>
        Task FormatAsync(Quran quran);       
    }
}
