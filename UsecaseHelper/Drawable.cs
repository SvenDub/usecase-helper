using System.Drawing;
using System.Windows.Forms;

namespace UsecaseHelper
{
    public abstract class Drawable
    {
        protected readonly Brush _brush = Brushes.Black;
        protected readonly Brush _brushGhost = Brushes.Black;

        protected readonly Font _font = new Font(FontFamily.GenericMonospace, 10);

        protected readonly Pen _pen = Pens.Black;
        protected readonly Pen _penGhost = Pens.Black;

        public int X { get; set; }
        public int Y { get; set; }
        public int GhostX { get; set; }
        public int GhostY { get; set; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public string Name { get; set; }
        protected Size TextSize => TextRenderer.MeasureText(Name, _font);

        public int Left => (int) (X - Width/2f);
        public int Right => (int) (X + Width/2f);
        public int Top => (int) (Y - Height/2f);
        public int Bottom => (int) (Y + Height/2f);

        public bool InSelection(int x, int y) => x >= Left && x <= Right && y >= Top && y <= Bottom;

        public void Draw(Graphics g)
        {
            g.TranslateTransform(-Width/2f, -Height/2f);

            DrawSelf(g);

            if (MainForm.DrawBoundingBox)
            {
                g.DrawRectangle(_pen, X, Y, Width, Height);
            }

            g.TranslateTransform(Width/2f, Height/2f);
        }

        public void DrawGhost(Graphics g)
        {
            g.TranslateTransform(-Width/2f, -Height/2f);

            DrawSelfGhost(g, GhostX, GhostY);

            if (MainForm.DrawBoundingBox)
            {
                g.DrawRectangle(_pen, X, Y, Width, Height);
            }

            g.TranslateTransform(Width/2f, Height/2f);
        }

        protected abstract void DrawSelf(Graphics g);
        protected abstract void DrawSelfGhost(Graphics g, int x, int y);

        public virtual void Edit()
        {
            string name = Prompt.ShowDialog("Name:", "Edit " + Name);
            if (!name.Equals(""))
            {
                Name = name;
            }
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}