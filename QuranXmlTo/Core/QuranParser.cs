using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using QuranXmlTo.Models;

namespace QuranXmlTo.Core
{
    /// <summary>
    /// Used to parse a quran resource.
    /// </summary>
    public class QuranParser
    {
        private readonly XDocument _xDoc;


        /// <summary>
        /// Initializes a new instance of the <see cref="QuranParser"/> class.
        /// </summary>
        /// <param name="quranXmlFile">The quran XML file.</param>
        public QuranParser(string quranXmlFile)
        {
            _xDoc = XDocument.Load(quranXmlFile);            
        }

        /// <summary>
        /// Parse the given xml file and return Quran object representation of it.
        /// </summary>
        /// <returns>Quran object.</returns>
        public Quran Parse()
        {
            var quran = new Quran();
            quran.Chapters = ParseChapters(quran);
            return quran;
        }

        /// <summary>
        /// Parses the chapters.
        /// </summary>
        /// <param name="quran">The quran.</param>
        /// <returns>Chapters.</returns>
        /// <exception cref="System.ArgumentException">The specified file is not recognized as a quran source file.</exception>
        private IEnumerable<Chapter> ParseChapters(Quran quran)
        {
            if (_xDoc.Root != null)
            {
                foreach (var xChapter in _xDoc.Root.Elements(XName.Get("sura")))
                {
                    var chapter = new Chapter(quran)
                    {
                        Index = Convert.ToInt32(xChapter.Attribute(XName.Get("index")).Value.Trim()),
                        Name = xChapter.Attribute(XName.Get("name")).Value.Trim(),
                    };
                    chapter.Verses = ParseVerses(xChapter, chapter);
                    yield return chapter;
                }
            }
            else
            {
                throw new ArgumentException("The specified file is not recognized as a quran source file.");
            }
        }

        /// <summary>
        /// Parses the verses.
        /// </summary>
        /// <param name="xChapter">The element of the chapter.</param>
        /// <param name="chapter">The chapter.</param>
        /// <returns>Verses.</returns>
        private IEnumerable<Verse> ParseVerses(XElement xChapter, Chapter chapter)
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            // Use loop to make it consistence as ParseChapters
            foreach (var xVerse in xChapter.Elements(XName.Get("aya")))
            {
                var verse = new Verse(chapter)
                {
                    Index = Convert.ToInt32(xVerse.Attribute(XName.Get("index")).Value.Trim()),
                    Text = xVerse.Attribute(XName.Get("text")).Value.Trim()
                };
                yield return verse;
            }
        }
    }
}
