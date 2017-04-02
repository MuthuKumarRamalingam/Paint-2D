using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using CommonTools;
using System.Drawing;

namespace MyPaint
{
    /// <summary>
    /// Storing Datas in File based Structure
    /// </summary>
    class FileDatainfo
    {
        #region Private variables
        private const string extType = ".MyExt";
        private const string extName = "MyExtension";
        private const int currentVersion = 1;
        private int version = currentVersion;

        #endregion

        #region Public propeties
        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public Dictionary<long, ShapeInfo> Shapes { get; set; }
        public List<string> SavedTime { get; set; }

        public Color PenColorDefault = Color.Red;
        public Color BackgrdColorDefault = Color.White;
        #endregion

        #region Constructor
        public FileDatainfo()
        {
            ClearAll();
        }

        #endregion

        #region Public Methods

        internal void SaveFile()
        {
            SavedTime.Add(DateTime.Now.ToString());

            JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            string Data = JsonConvert.SerializeObject(this, settings);

            string path;
            if (FileOperations.GetSavePath(out path, extType, extType))
            {
                if (FileOperations.Write(path, Data, true))
                {
                    MessageBox.Show("Successfully saved");
                    ClearAll();
                }
            }
        }

        internal void OpenFile()
        {
            string path;
            if (FileOperations.GetOpenFilePath(out path, extType, extType))
            {
                string Data;
                if (FileOperations.Read(path, out Data))
                {
                    ClearAll();
                    loadData(Data);
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

        internal string GetSaveLog()
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

        #endregion

        #region Private Methods
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
        #endregion
    }
}
