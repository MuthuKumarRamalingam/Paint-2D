using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    public class LineBasic
    {
        #region constructor
        public LineBasic()
        {
            Point1 = new List<Point>();
            Point2 = new List<Point>();
            Color = new List<Color>();
        }
        #endregion constructor

        #region variables

        public List<Point> Point1;
        public List<Point> Point2;
        public List<Color> Color;
        #endregion

        #region Methods
        public void Add(Point _Point1, Point _Point2, Color _Color)
        {
            Point1.Add(_Point1);
            Point2.Add(_Point2);
            Color.Add(_Color);
        }
        public void Add(int Pt1X, int Pt1Y, int Pt2X, int Pt2Y, Color _Color)
        {
            Add(new Point(Pt1X, Pt1Y), new Point(Pt2X, Pt2Y), _Color);
        }
        #endregion

    }

    public class EllipseBasic
    {
        #region constructor
        public EllipseBasic()
        {
            Point1 = new List<Point>();
            Size = new List<Size>();
            Color = new List<Color>();

        }
        #endregion constructor

        #region variables
        public List<Point> Point1;
        public List<Size> Size;
        public List<Color> Color;
        #endregion

        #region Methods
        public Rectangle Rect(int index)
        {
            return new Rectangle(Point1[index], Size[index]);
        }

        public void Add(Point _Point1, Point _Point2, Color _Color)
        {
            int Width = _Point2.X - _Point1.X;
            int Height = _Point2.Y - _Point1.Y;

            if (Width < 0)
                _Point1 = new Point((_Point1.X + Width), _Point1.Y);
            if (Height < 0)
                _Point1 = new Point(_Point1.X, (_Point1.Y + Height));

            Height = Math.Abs(Height);
            Width = Math.Abs(Width);

            Point1.Add(_Point1);
            Size.Add(new Size(Width, Height));
            Color.Add(_Color);
        }
        #endregion
    }

    public class RectangleBasic
    {
        #region constructor
        public RectangleBasic()
        {
            Point1 = new List<Point>();
            Size = new List<Size>();
            Color = new List<Color>();
        }
        #endregion constructor

        #region variables
        public List<Point> Point1;
        public List<Size> Size;
        public List<Color> Color;
        #endregion

        #region Methods
        public Rectangle Rect(int index)
        {
            return new Rectangle(Point1[index], Size[index]);
        }

        public void Add(Point stPoint, Point endPoint, Color _Color)
        {

            int Width = endPoint.X - stPoint.X;
            int Height = endPoint.Y - stPoint.Y;

            if (Width < 0)
                stPoint = new Point((stPoint.X + Width), stPoint.Y);
            if (Height < 0)
                stPoint = new Point(stPoint.X, (stPoint.Y + Height));

            Height = Math.Abs(Height);
            Width = Math.Abs(Width);

            Point1.Add(stPoint);
            Size.Add(new Size(Width, Height));
            Color.Add(_Color);
        }
        #endregion
    }

   
}
