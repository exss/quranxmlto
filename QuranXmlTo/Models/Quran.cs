using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranXmlTo.Models
{
    /// <summary>
    /// Model of a quran.
    /// </summary>
    public class Quran
    {
        /// <summary>
        /// Gets or sets the chapters for the quran.
        /// </summary>
        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
