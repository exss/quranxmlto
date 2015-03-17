using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuranXmlTo.Models;

namespace QuranXmlTo.Formatter
{
    /// <summary>
    /// Separator used to separate entry fields.
    /// </summary>
    public enum CsvSeparator
    {
        Comma,
        Semicolon
    }

    /// <summary>
    /// Output a quran into a list of csv files.
    /// </summary>
    public class CsvQuranFormatter : FileQuranFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvQuranFormatter"/> class.
        /// </summary>
        /// <param name="outputDirectory">The output directory.</param>
        public CsvQuranFormatter(string outputDirectory)
            : base(outputDirectory)
        {
        }

        /// <summary>
        /// Gets or sets the separator used to separate fields on the quran entry.
        /// </summary>
        /// <value>
        /// The separator.
        /// </value>
        public CsvSeparator Separator { get; set; }

        public override void Format(Quran quran)
        {
            var separator = Separator == CsvSeparator.Comma ? ',' : ';';
            using (var metadataFile = File.Create(Path.Combine(OutputDirectory, "metadata.csv")))
            {
                using (var metadataWriter = new StreamWriter(metadataFile))
                {
                    foreach (var chapter in quran.Chapters)
                    {
                        metadataWriter.WriteLine(chapter.Index + separator + chapter.Name);

                        using (var chapterFile = File.Create(Path.Combine(OutputDirectory, chapter.Index + ".csv")))
                        {
                            using (var chapterWriter = new StreamWriter(chapterFile))
                            {
                                foreach (var verse in chapter.Verses)
                                {
                                    chapterWriter.WriteLine(verse.Index + separator + verse.Text);
                                }
                                chapterWriter.Flush();
                            }
                        }
                        metadataWriter.Flush();
                    }
                }
            }

        }

        public override async Task FormatAsync(Quran quran)
        {
            var separator = Separator == CsvSeparator.Comma ? ',' : ';';
            using (var metadataFile = File.Create(Path.Combine(OutputDirectory, "metadata.csv")))
            {
                using (var metadataWriter = new StreamWriter(metadataFile))
                {
                    foreach (var chapter in quran.Chapters)
                    {
                        await metadataWriter.WriteLineAsync(chapter.Index + separator + chapter.Name);

                        using (var chapterFile = File.Create(Path.Combine(OutputDirectory, chapter.Index + ".csv")))
                        {
                            using (var chapterWriter = new StreamWriter(chapterFile))
                            {
                                foreach (var verse in chapter.Verses)
                                {
                                    await chapterWriter.WriteLineAsync(verse.Index + separator + verse.Text);
                                }
                                await chapterWriter.FlushAsync();
                            }
                        }
                        await metadataWriter.FlushAsync();
                    }
                }
            }
        }
    }
}
