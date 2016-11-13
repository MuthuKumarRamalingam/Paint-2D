using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    public static class CommonHelper
    {
        public static Rectangle GetRect(Point _Point1, Point _Point2)
        {
            int Width = _Point2.X - _Point1.X;
            int Height = _Point2.Y - _Point1.Y;
            if (Width < 0)
                _Point1 = new Point((_Point1.X + Width), _Point1.Y);
            if (Height < 0)
                _Point1 = new Point(_Point1.X, (_Point1.Y + Height));

            Height = Math.Abs(Height);
            Width = Math.Abs(Width);

            return new Rectangle(_Point1, new Size(Width, Height));
        }
    }
}
