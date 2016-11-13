using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    public enum EntityType
    {
        Line,
        Ellipse,
        Rectangle,
    }

    class ShapeInfo
    {
        public Color EntityColor { get; set; }
        public long UniqueID { get; set; }
        public EntityType EntityType { get; set; }

        private static long UniqueIDCounter = 0;

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


        protected Pen GetPen()
        {
            return new Pen(EntityColor);
        }

        internal static void ResetUniqueID()
        {
            UniqueIDCounter = 0;
        }
    }


}
