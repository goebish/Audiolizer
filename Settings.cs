﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Audiolizer
{
    [Serializable]
    public class Settings
    {
        public const string Extension = ".testInfo";

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

        public Settings()
        {
            InputName = "";
            LedBarIP = "";
            Smoothing = 7;
            Mode = "PeakVolume";
            SpectrumFilter = new List<int>();
            SpectrumFilter.Add(4);
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