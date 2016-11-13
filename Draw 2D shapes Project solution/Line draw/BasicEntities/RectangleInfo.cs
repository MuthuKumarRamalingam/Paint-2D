using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    [Serializable]
    class RectangleInfo : ShapeInfo, Ishapes
    {
        public Point StPoint { get; set; }
        public Point EdPoint { get; set; }

        public RectangleInfo(Point stPoint, Point endPoint, Color entityColor, EntityType entityType)
            : base(entityColor, entityType)
        {
            InitRect(stPoint, endPoint, entityColor);
        }

        private void InitRect(Point stPoint, Point endPoint, Color entityColor)
        {
            this.StPoint = stPoint;
            this.EdPoint = endPoint;
        }

        private Rectangle GetRect()
        {
            return CommonHelper.GetRect(StPoint, EdPoint);
        }

        void Ishapes.Render(Graphics Graphics)
        {
            if (EntityType == MyPaint.EntityType.Rectangle)
            {
                Graphics.DrawRectangle(GetPen(), GetRect());

            }
            else if (EntityType == MyPaint.EntityType.Ellipse)
            {
                Graphics.DrawEllipse(GetPen(), GetRect());
            }
        }
    }
}
