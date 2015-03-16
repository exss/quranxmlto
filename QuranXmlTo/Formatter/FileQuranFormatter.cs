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
    /// A formatter that output the new format to a file.
    /// </summary>
    public abstract class FileQuranFormatter : IQuranFormatter
    {
        public string OutputDirectory { get; set; }

        protected FileQuranFormatter(string outputDirectory)
        {
            OutputDirectory = outputDirectory;
            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }
            OutputDirectoryHandle = new DirectoryInfo(OutputDirectory);
        }

        protected DirectoryInfo OutputDirectoryHandle { get; set; }

        public abstract void Format(Quran quran);
        public abstract Task FormatAsync(Quran quran);
    }
}
