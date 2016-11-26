using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using CommonTools;

namespace MyPaint
{
    class ShapesData
    {
        private const int currentVersion = 1;

        private int version = currentVersion;

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public Dictionary<long, ShapeInfo> Shapes { get; set; }

        public List<string> SavedTime { get; set; }


        public ShapesData()
        {
            ClearAll();
        }


        internal void SaveFile()
        {

            SavedTime.Add(DateTime.Now.ToString());

            JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            string Data = JsonConvert.SerializeObject(this, settings);

            string path;
            if (FileOperations.GetSavePath(out path))
            {
                if (FileOperations.Write(path, Data, true))
                {
                    MessageBox.Show("Successfully saved");
                    ClearAll();
                }
            }
        }

        internal void ClearAll(bool resetTime = true)
        {
            Shapes = new Dictionary<long, ShapeInfo>();
            ShapeInfo.ResetUniqueID();

            if (resetTime)
                SavedTime = new List<string>();
        }


        internal void OpenFile()
        {
            string path;
            if (FileOperations.GetOpenFilePath(out path))
            {
                string Data;
                if (FileOperations.Read(path, out Data))
                {
                    ClearAll();
                    loadData(Data);
                }
            }

        }

        private void loadData(string data)
        {
            if (data.IsNotNullorEmpty())
            {
                JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                JsonConvert.PopulateObject(data, this, settings);
                versionMigrate();
            }
        }

        private void versionMigrate()
        {
            switch (version)
            {
                case 1:

                    break;
                default:
                    throw new MigrateException(currentVersion, version);
            }
        }

        public string GetSaveLog()
        {
            StringBuilder message = new StringBuilder();
            if (SavedTime.Count > 0)
            {
                message.AppendLine(string.Format("You saved {0} times", SavedTime.Count));
                for (int i = 0; i < SavedTime.Count; i++)
                {
                    message.AppendLine(string.Format("Save {0} on {1}", i + 1, SavedTime[i]));
                }
            }
            else
            {
                message.Append("U doesn't save this file, Please save this File");
            }

            return message.ToString();
        }

    }
}
