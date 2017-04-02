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
        private Panel PnlDraw;

        internal RenderInfo(Panel paintPanel)
        {
            PnlDraw = paintPanel;
            fileDatas = new FileDatainfo();
        }

        internal void AddEntity(Point stPoint, Point endPoint, EntityType entityType, bool tempEntity = false,string userText="")
        {
            Color entityColor = fileDatas.PenColorDefault;

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
                case EntityType.Text:
                    {
                        EInfo = new TextInfo(stPoint, userText, new Font("Arial", 10), entityColor);
                    }
                    break;
                default:
                    throw new NotImplementedException(entityType.ToString());
            }

            if (!tempEntity)
                fileDatas.Shapes.Add(EInfo.UniqueID, EInfo);

            Graphics Graphics = DrawSavedShapes();

            if (tempEntity)
                EInfo.Render(Graphics);
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


        internal Graphics DrawSavedShapes()
        {
            Graphics Graphics = ClearGraphicsPanel();

            Render(Graphics);

            return Graphics;
        }

        private Graphics ClearGraphicsPanel()
        {
            Bitmap bmp = new Bitmap(PnlDraw.Size.Width, PnlDraw.Size.Height);
            Graphics Graphics = Graphics.FromImage(bmp);

            PnlDraw.BackColor = fileDatas.BackgrdColorDefault;
            PnlDraw.BackgroundImage = bmp;

            return Graphics;
        }

        private void Render(Graphics Graphics)
        {
            foreach (KeyValuePair<long, ShapeInfo> eachEntity in fileDatas.Shapes)
            {
                ShapeInfo shap = eachEntity.Value;
                shap.Render(Graphics);
            }
        }

    }
}
