using System;
using System.Drawing;

namespace UsecaseHelper
{
    /// <summary>
    ///     Represents an actor that can be linked to a use case.
    /// </summary>
    public class Actor : Drawable
    {
        /// <summary>
        ///     The width of this actor, depending on the length of its name.
        /// </summary>
        public override int Width => Math.Max(50, TextSize.Width);

        /// <summary>
        ///     The height of this actor, depending on the height of its name.
        /// </summary>
        public override int Height => 100 + 5 + TextSize.Height;

        protected override void DrawSelf(Graphics g)
        {
            DrawSelf(g, Pen, Brush, X, Y);
        }

        protected override void DrawSelfGhost(Graphics g, int x, int y)
        {
            DrawSelf(g, PenGhost, BrushGhost, x, y);
        }

        /// <summary>
        ///     Draws this actor.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        /// <param name="pen">The pen to use for drawing.</param>
        /// <param name="brush">The brush to use for drawing.</param>
        /// <param name="x">The x-coordinate of the top left corner.</param>
        /// <param name="y">The y-coordinate of the top left corner.</param>
        private void DrawSelf(Graphics g, Pen pen, Brush brush, int x, int y)
        {
            // Head
            g.DrawEllipse(pen, x + Width/2 - 15, y + 10, 30, 30);
            // Body
            g.DrawLine(pen, x + Width/2, y + 40, x + Width/2, y + 80);
            // Right leg
            g.DrawLine(pen, x + Width/2, y + 80, x + Width/2 + 15, y + 100);
            // Left leg
            g.DrawLine(pen, x + Width/2, y + 80, x + Width/2 - 15, y + 100);
            // Arms
            g.DrawLine(pen, x + Width/2 - 15, y + 50, x + Width/2 + 15, y + 50);

            // Name
            g.DrawString(Name, Font, brush, x + Width/2 - TextSize.Width/2, y + 100 + 5);
        }

        public override string ToString() => Name;
    }
}