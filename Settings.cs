using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Audiolizer
{
    [Serializable]
    public class Settings
    {
        [XmlElement]
        public string InputName { get; set; }

        [XmlElement]
        public string LedBarIP { get; set; }

        [XmlElement]
        public string Mode { get; set; }

        [XmlElement]
        public int Smoothing { get; set; }

        [XmlElement]
        public List<int> SpectrumFilter { get; set; }

        [XmlElement]
        public int Scaling { get; set; }

        public Settings()
        {
            InputName = "";
            LedBarIP = "";
            Smoothing = 7;
            Mode = "PeakVolume";
            SpectrumFilter = new List<int>();
            Scaling = 5;
        }

        public void Save(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextWriter textWriter = new StreamWriter(filePath);
            serializer.Serialize(textWriter, this);
            textWriter.Close();
        }

        public static Settings Load(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextReader reader = new StreamReader(filePath);
            Settings data = (Settings)serializer.Deserialize(reader);
            reader.Close();

            return data;
        }
    }
}
