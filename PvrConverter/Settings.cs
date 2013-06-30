using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PvrConverter
{
    public class Settings
    {
        /// <summary>
        /// Load up a settings instance from file given a filename
        /// Will create a new settings file if one does not already exist 
        /// </summary>
        /// <param name="filename">The name of the settings file</param>
        /// <returns>A Settings instance</returns>
        public static Settings Load(string filename)
        {
            if (!File.Exists(filename))
            {
                new Settings().Save(filename);
            }

            Settings result;

            using (FileStream stream = File.OpenRead(filename))
            {
                result = new XmlSerializer(typeof(Settings)).Deserialize(stream) as Settings;
            }

            return result;
        }

        /// <summary>
        /// Save this Settings instance as XML
        /// </summary>
        /// <param name="filename">The filename of the file</param>
        public void Save(string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.CreateNew))
            {
                new XmlSerializer(typeof(Settings)).Serialize(stream, this);
            }
        }

        /// <summary>
        /// Settings ToString override
        /// </summary>
        /// <returns>The current values of this settings instance as XML</returns>
        public override string ToString()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new XmlSerializer(base.GetType()).Serialize((Stream)stream, this);
                stream.Position = 0L;
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
