using System.Drawing;

namespace UsecaseHelper
{
    public abstract class Drawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }

        public abstract void Draw(Graphics g);
    }
}
