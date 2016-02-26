using System.Drawing;
using System.Windows.Forms;

namespace UsecaseHelper
{
    public abstract class Drawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public string Name { get; set; }

        protected readonly Pen _pen = Pens.Black;
        protected readonly Brush _brush = Brushes.Black;

        protected readonly Font _font = new Font(FontFamily.GenericMonospace, 10);

        protected Size TextSize => TextRenderer.MeasureText(Name, _font);

        public virtual void Draw(Graphics g)
        {
            if (MainForm.DrawBoundingBox)
            {
                g.DrawRectangle(_pen, X, Y, Width, Height);
            }
        }

        public bool InSelection(int x, int y) => x >= X && x <= X + Width && y >= Y && y <= Y + Height;
    }
}
