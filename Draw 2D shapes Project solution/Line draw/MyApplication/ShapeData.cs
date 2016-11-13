using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace MyPaint
{
    public class ShapeData
    {
        #region constructor

        public ShapeData()
        {
            objLine = new LineBasic();
            objEllipse = new EllipseBasic();
            objRectangle = new RectangleBasic();
        }

        #endregion

        #region private variables
        private int version = 0;

        private LineBasic objLine = new LineBasic();
        private EllipseBasic objEllipse = new EllipseBasic();
        private RectangleBasic objRectangle = new RectangleBasic();

        #endregion

        #region public properties
        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public LineBasic ObjLine
        {
            get { return objLine; }
            set { objLine = value; }
        }
        public EllipseBasic ObjEllipse
        {
            get { return objEllipse; }
            set { objEllipse = value; }
        }
        public RectangleBasic ObjRectangle
        {
            get { return objRectangle; }
            set { objRectangle = value; }
        }

        #endregion

        #region methods

        internal void OpenFile()
        {
            string path;
            if (FileOperations.GetOpenFilePath(out path))
            {
                string Data;
                if (FileOperations.Read(path, out Data))
                {
                    Clear();
                    if (Data.IsNotNullorEmpty())
                        JsonConvert.PopulateObject(Data, this);
                }
            }
        }

        internal void SaveFile()
        {
            string Data = JsonConvert.SerializeObject(this);

            string path;
            if (FileOperations.GetSavePath(out path))
            {
                if (FileOperations.Write(path, Data))
                    MessageBox.Show("Successfully saved");
            }

        }

        internal void Clear()
        {
            objLine = new LineBasic();
            objEllipse = new EllipseBasic();
            objRectangle = new RectangleBasic();
        }
        #endregion
    }
}
