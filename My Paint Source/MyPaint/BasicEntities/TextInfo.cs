using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    class TextInfo : ShapeInfo
    {
        public Point StPoint { get; set; }
        public string Content { get; set; }
        public Font StyleFont { get; set; }

        public TextInfo()
        { }

        internal TextInfo(Point stPoint, string content, Font styleFont, Color entityColor)
            : base(entityColor, EntityType.Text)
        {
            StPoint = stPoint;
            Content = content;
            StyleFont = styleFont;
        }

        public override void Render(Graphics Graphics)
        {
            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;

            Graphics.DrawString(Content, StyleFont, GetBrush(), StPoint, fmt);
        }
    }
}
