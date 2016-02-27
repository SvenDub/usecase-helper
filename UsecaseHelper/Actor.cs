using System;
using System.Drawing;

namespace UsecaseHelper
{
    public class Actor : Drawable
    {
        public override int Width => Math.Max(50, TextSize.Width);
        public override int Height => 100 + 5 + TextSize.Height;

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            g.DrawEllipse(_pen, X + Width / 2 - 15, Y + 10, 30, 30);
            g.DrawLine(_pen, X + Width / 2, Y + 40, X + Width / 2, Y + 80);
            g.DrawLine(_pen, X + Width / 2, Y + 80, X + Width / 2 + 15, Y + 100);
            g.DrawLine(_pen, X + Width / 2, Y + 80, X + Width / 2 - 15, Y + 100);
            g.DrawLine(_pen, X + Width / 2 - 15, Y + 50, X + Width / 2 + 15, Y + 50);

            g.DrawString(Name, _font, _brush, X + (Width / 2) - (TextSize.Width / 2), Y + 100 + 5);
        }
    }
}
