using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Line_draw
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

        private LineBasic objLine = new LineBasic();
        private EllipseBasic objEllipse = new EllipseBasic();
        private RectangleBasic objRectangle = new RectangleBasic();

        #endregion

        #region public properties
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
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Filter = "MyExtension (*.MyExt)|*MyExt";
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                string Data = File.ReadAllText(OpenDlg.FileName);
                //StreamReader Reader = new StreamReader(OpenDlg.FileName);
                //while (!Reader.EndOfStream)
                //    Data = Reader.ReadLine();
                //Reader.Close();
                Clear();
                if (Data.IsNotNullorEmpty())
                    JsonConvert.PopulateObject(Data, this);

            }
        }
        internal void SaveFile()
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "MyExtension (*.MyExt)|*MyExt";
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                string Data = JsonConvert.SerializeObject(this);

                using (StreamWriter Writer = new StreamWriter(SaveDlg.FileName + ".MyExt"))
                {
                    Writer.Write(Data);
                    Writer.Close();
                }
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
