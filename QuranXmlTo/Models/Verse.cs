using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuranXmlTo.Models
{
    /// <summary>
    /// Model of a quran verse.
    /// </summary>
    public class Verse
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Verse"/> class.
        /// </summary>
        /// <param name="chapter">The chapter that owns this verse.</param>
        public Verse(Chapter chapter)
        {
            Chapter = chapter;
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
        /// <summary>
        /// Gets the chapter that owns this verse.
        /// </summary>
        /// <value>
        /// The chapter.
        /// </value>                
        public Chapter Chapter { get; private set; }
    }
}
