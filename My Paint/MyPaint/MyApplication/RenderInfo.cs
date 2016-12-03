using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace MyPaint
{
    class RenderInfo
    {
        public FileDatainfo fileDatas;

        private Graphics Graphics;
        private Bitmap bmp;

        public static Color PenColor = Color.Red;
        public Color BackgrdColor = Color.White;

        private Size areaSize;
        private Panel PnlDraw;

        internal RenderInfo(Panel paintPanel)
        {
            PnlDraw = paintPanel;

            this.areaSize = paintPanel.Size;
            fileDatas = new FileDatainfo();
        }


        internal void AddEntity(Point stPoint, Point endPoint, EntityType entityType, bool tempEntity = false)
        {
            Color entityColor = PenColor;

            ShapeInfo EInfo = null;
            switch (entityType)
            {

                case EntityType.Line:
                    {
                        EInfo = new LineInfo(stPoint, endPoint, entityColor);
                    }
                    break;

                case EntityType.Rectangle:
                    {
                        EInfo = new RectangleInfo(stPoint, endPoint, entityColor, entityType);
                    }

                    break;
                case EntityType.Ellipse:
                    {
                        EInfo = new RectangleInfo(stPoint, endPoint, entityColor, entityType);
                    }
                    break;
                default:
                    throw new NotImplementedException(entityType.ToString());
            }

            if (!tempEntity)
                fileDatas.Shapes.Add(EInfo.UniqueID, EInfo);

            DrawSavedShapes();

            if (tempEntity)
                EInfo.Render(Graphics);
        }

        internal Bitmap DrawSavedShapes()
        {
            ClearGraphicsPanel();

            Render(Graphics);

            PnlDraw.BackgroundImage = bmp;

            return bmp;
        }


        internal void ClearAll()
        {
            fileDatas.ClearAll(false);
            DrawSavedShapes();
        }

        internal void OpenFile()
        {
            fileDatas.OpenFile();
            DrawSavedShapes();
        }

        internal void SaveFile()
        {
            fileDatas.SaveFile();
            DrawSavedShapes();
        }


        private Bitmap ClearGraphicsPanel()
        {
            PnlDraw.BackColor = BackgrdColor;
            bmp = new Bitmap(areaSize.Width, areaSize.Height);
            Graphics = Graphics.FromImage(bmp);

            return bmp;
        }

        private Bitmap Render(Graphics Graphics)
        {
            foreach (KeyValuePair<long, ShapeInfo> eachEntity in fileDatas.Shapes)
            {
                ShapeInfo shap = eachEntity.Value;
                shap.Render(Graphics);
            }

            return bmp;
        }

    }
}
