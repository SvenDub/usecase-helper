using System;
using System.Drawing;

namespace UsecaseHelper
{
    public class Actor : Drawable
    {
        public override int Width => Math.Max(50, TextSize.Width);
        public override int Height => 100 + 5 + TextSize.Height;

        protected override void DrawSelf(Graphics g)
        {
            DrawSelf(g, _pen, _brush, X, Y);
        }

        protected override void DrawSelfGhost(Graphics g, int x, int y)
        {
            DrawSelf(g, _penGhost, _brushGhost, x, y);
        }

        private void DrawSelf(Graphics g, Pen pen, Brush brush, int x, int y)
        {
            g.DrawEllipse(pen, x + Width/2 - 15, y + 10, 30, 30);
            g.DrawLine(pen, x + Width/2, y + 40, x + Width/2, y + 80);
            g.DrawLine(pen, x + Width/2, y + 80, x + Width/2 + 15, y + 100);
            g.DrawLine(pen, x + Width/2, y + 80, x + Width/2 - 15, y + 100);
            g.DrawLine(pen, x + Width/2 - 15, y + 50, x + Width/2 + 15, y + 50);

            g.DrawString(Name, _font, brush, x + Width/2 - TextSize.Width/2, y + 100 + 5);
        }

        public override string ToString() => Name;
    }
}