using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    abstract class ShapeInfo : Ishapes
    {
        #region Public properties
        public Color EntityColor { get; set; }
        public long UniqueID { get; set; }
        public EntityType EntityType { get; set; }

        #endregion

        #region Constructor
        public ShapeInfo()
        {
            // TODO: Complete member initialization
        }
        public ShapeInfo(Color _entityColor, EntityType entityType)
        {
            // TODO: Complete member initialization
            this.EntityColor = _entityColor;
            this.EntityType = entityType;

            UniqueID = ++UniqueIDCounter;
        }

        #endregion

        protected Pen GetPen()
        {
            return new Pen(GetBrush());
        }

        protected Brush GetBrush()
        {
            return new SolidBrush(EntityColor);
        }

        public abstract void Render(Graphics Graphics);

        private static long UniqueIDCounter = 0;

        internal static void ResetUniqueID()
        {
            UniqueIDCounter = 0;
        }

    }

    internal enum EntityType
    {
        Line,
        Ellipse,
        Rectangle,
        Text,
    }
}
