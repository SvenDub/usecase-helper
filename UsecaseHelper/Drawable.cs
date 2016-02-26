using System.Drawing;

namespace UsecaseHelper
{
    public abstract class Drawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }

        public abstract void Draw(Graphics g);

        public bool InSelection(int x, int y) => x >= X && x <= X + Width && y >= Y && y <= Y + Height;
    }
}
