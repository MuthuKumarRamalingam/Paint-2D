using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    [Serializable]
    /// <summary>
    /// Line in 2D window.
    /// </summary>
    class LineInfo : ShapeInfo, Ishapes
    {
        #region Properties
        /// <summary>
        /// Start point in 2d Window.
        /// </summary>
        public Point StPoint { get; set; }

        /// <summary>
        /// End Point in 2d Window.
        /// </summary>
        public Point EndPoint { get; set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for json
        /// </summary>
        public LineInfo()
        {
        }

        /// <summary>
        /// Intialize Line
        /// </summary>
        /// <param name="stPoint">Start Point of Line</param>
        /// <param name="endPoint">End Point of Line</param>
        /// <param name="entityColor">Color of Line</param>
        internal LineInfo(Point stPoint, Point endPoint, Color entityColor)
            : base(entityColor, EntityType.Line)
        {
            this.StPoint = stPoint;
            this.EndPoint = endPoint;
        }

        /// <summary>
        /// Intialize Line using integer points
        /// </summary>
        /// <param name="stPointX">Start point of Line X  Position</param>
        /// <param name="stPointY">Start point of Line Y Position</param>
        /// <param name="endPointX">End point of Line X  Position</param>
        /// <param name="endPointY">End point of Line Y Position</param>
        /// <param name="entityColor">Color of Line</param>
        internal LineInfo(int stPointX, int stPointY, int endPointX, int endPointY, Color entityColor)
            : base(entityColor, EntityType.Line)
        {
            this.StPoint = new Point(stPointX, stPointY);
            this.EndPoint = new Point(endPointX, endPointY);
        }
        
        #endregion

        #region Ishapes Members

        /// <summary>
        /// Defines How to Draw 
        /// </summary>
        /// <param name="Graphics"></param>
        void Ishapes.Render(Graphics Graphics)
        {
            Graphics.DrawLine(GetPen(), StPoint, EndPoint);
        }

        #endregion
    }
}
