using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuranXmlTo.Models;

namespace QuranXmlTo.Formatter
{
    internal class JsonQuranSerializationContract : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            List<MemberInfo> serialized = new List<MemberInfo>();
            if (objectType == typeof(Chapter))
            {
                serialized.AddRange(
                    objectType.GetMembers().Where(memberInfo =>
                        memberInfo.DeclaringType != typeof (Quran) && memberInfo.MemberType == MemberTypes.Property)
                    );
            }
            if (objectType == typeof (Verse))
            {
                serialized.AddRange(
                    objectType.GetMembers().Where(memberInfo => 
                        memberInfo.DeclaringType != typeof(Chapter) && memberInfo.MemberType == MemberTypes.Property)
                    );
            }
            return serialized;
        }
    }
    /// <summary>
    /// Output a quran into a list of json files based on the chapter.
    /// </summary>
    public class JsonQuranFormatter : FileQuranFormatter
    {        
        public JsonQuranFormatter(string outputDirectory) : base(outputDirectory)
        {
            Initialize();
        }

        private void Initialize()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new JsonQuranSerializationContract()
            };
        }

        /// <summary>
        /// Gets or sets the settings for json serialization.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public JsonSerializerSettings Settings { get; set; }


        public override void Format(Quran quran)
        {
            
            foreach (var chapter in quran.Chapters)
            {
                using (var file = File.Create(Path.Combine(OutputDirectory, chapter.Index + ".json")))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        writer.Write(JsonConvert.SerializeObject(chapter,Settings));
                        writer.Flush();
                    }
                }
            }
        }

        public override async Task FormatAsync(Quran quran)
        {
            foreach (var chapter in quran.Chapters)
            {
                using (var file = File.Create(Path.Combine(OutputDirectory, chapter.Index + ".json")))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        await writer.WriteAsync(JsonConvert.SerializeObject(chapter, Settings));
                        await writer.FlushAsync();
                    }
                }
            }
        }
    }
}
