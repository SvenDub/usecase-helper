using System.Drawing;

namespace UsecaseHelper
{
    public class Actor : Drawable
    {
        private readonly Pen _pen = Pens.Black;
        private readonly Brush _brush = Brushes.Black;

        public Actor()
        {
            Width = 50;
            Height = 100;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(_pen, X, Y, Width, Height);
            g.DrawString(Name, new Font(FontFamily.GenericMonospace, 10), _brush, new RectangleF(X, Y + Height, 100, 50));
        }
    }
}
