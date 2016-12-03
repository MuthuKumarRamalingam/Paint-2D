using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    interface Ishapes
    {
        /// <summary>
        /// Defines color of Entity.
        /// </summary>
        Color EntityColor { get; set; }

        /// <summary>
        /// Unique Id of Entity.
        /// </summary>
        long UniqueID { get; set; }

        /// <summary>
        /// Defines Type of entity to draw.
        /// </summary>
        EntityType EntityType { get; set; }

        /// <summary>
        /// Describes how to draw given shape.
        /// </summary>
        /// <param name="Graphics"></param>
        void Render(Graphics Graphics);
    }
}
