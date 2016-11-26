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
        public ShapesData ShapesData;

        Graphics Graphics;
        Bitmap bmp;
        public static Color PenColor = Color.Red;
        public Color BackgrdColor = Color.White;

        Size areaSize;
        Panel PnlDraw;

        public RenderInfo(Panel paintPanel)
        {
            PnlDraw = paintPanel;

            this.areaSize = paintPanel.Size;
            ShapesData = new ShapesData();
        }

        public Bitmap ClearGraphicsPanel()
        {
            PnlDraw.BackColor = BackgrdColor;
            bmp = new Bitmap(areaSize.Width, areaSize.Height);
            Graphics = Graphics.FromImage(bmp);

            return bmp;
        }

        public Bitmap DrawSavedShapes()
        {
            ClearGraphicsPanel();

            Render(Graphics);

            PnlDraw.BackgroundImage = bmp;

            return bmp;
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
                    break;
            }
            if (!tempEntity)
                ShapesData.Shapes.Add(EInfo.UniqueID, EInfo);

            DrawSavedShapes();

            if (tempEntity)
                ((Ishapes)EInfo).Render(Graphics);
        }

        internal Bitmap Render(Graphics Graphics)
        {
            foreach (KeyValuePair<long, ShapeInfo> eachEntity in ShapesData.Shapes)
            {
                ShapeInfo shap = eachEntity.Value;
                Type T = shap.GetType();
                ((Ishapes)eachEntity.Value).Render(Graphics);
            }

            return bmp;
        }



        internal void ClearAll()
        {
            ShapesData.ClearAll(false);
            DrawSavedShapes();
        }

        internal void OpenFile()
        {
            ShapesData.OpenFile();
            DrawSavedShapes();
        }

        internal void SaveFile()
        {
            ShapesData.SaveFile();
            DrawSavedShapes();
        }
    }
}
