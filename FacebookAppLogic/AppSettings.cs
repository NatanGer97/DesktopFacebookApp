using System;
using System.IO;
using System.Xml.Serialization;

namespace FacebookAppLogic
{
    public class AppSettings
    {
        private const string k_FileName = "AppSettings.xml";
        public static readonly AppSettings sr_Instance = new AppSettings();

        public bool Remember { get; set; }

        public string AccessToken { get; set; }

        static AppSettings()
        {
        }

        private AppSettings()
        {
            Remember = false;
            AccessToken = null;
        }

        public static AppSettings Instance => sr_Instance;

        public static AppSettings LoadFromFile()
        {
            AppSettings obj = new AppSettings();

            if (File.Exists(k_FileName))
            {
                using (Stream stream = new FileStream(k_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));

                    obj = serializer.Deserialize(stream) as AppSettings;
                }
            }

            return obj;
        }

        public void SaveToFile()
        {
            if (File.Exists(k_FileName))
            {
                using (Stream stream = new FileStream(k_FileName, FileMode.Truncate))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());

                    serializer.Serialize(stream, this);
                }
            }
            else
            {
                using (Stream stream = new FileStream(k_FileName, FileMode.CreateNew))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());

                    serializer.Serialize(stream, this);
                }
            }
        }
    }
}
