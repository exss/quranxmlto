using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuranXmlTo.Models
{
    /// <summary>
    /// Model of a quran chapter.
    /// </summary>
    public class Chapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chapter"/> class.
        /// </summary>
        /// <param name="quran">The quran that owns this chapter.</param>
        public Chapter(Quran quran)
        {
            Quran = quran;            
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the quran that owns this chapter.
        /// </summary>
        /// <value>
        /// The quran.
        /// </value>        
        public Quran Quran { get; private set; }

        /// <summary>
        /// Gets or sets the verses.
        /// </summary>
        /// <value>
        /// The verses.
        /// </value>
        public IEnumerable<Verse> Verses { get; set; }
    }
}
