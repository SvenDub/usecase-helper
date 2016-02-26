using System.Drawing;

namespace UsecaseHelper
{
    public class Actor : Drawable
    {
        private readonly Pen _pen = Pens.Black;
        private readonly Brush _brush = Brushes.Black;

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(_pen, X, Y, 50, 100);
            g.DrawString(Name, new Font(FontFamily.GenericMonospace, 10), _brush, new RectangleF(X, Y + 100, 100, 50));
        }
    }
}
