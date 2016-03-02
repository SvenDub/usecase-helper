using System.Drawing;
using System.Windows.Forms;

namespace UsecaseHelper
{
    /// <summary>
    ///     An object in the use case diagram that can be drawn.
    /// </summary>
    public abstract class Drawable
    {
        /// <summary>
        ///     The brush to use when drawing in normal mode.
        /// </summary>
        protected Brush Brush { get; set; } = Brushes.Black;

        /// <summary>
        ///     The brush to use when drawing in ghost mode.
        /// </summary>
        protected Brush BrushGhost { get; set; } = Brushes.Black;

        /// <summary>
        ///     The font to use for drawing the name.
        /// </summary>
        protected Font Font { get; set; } = new Font(FontFamily.GenericMonospace, 10);

        /// <summary>
        ///     The pen to use when drawing in normal mode.
        /// </summary>
        protected Pen Pen { get; set; } = Pens.Black;

        /// <summary>
        ///     The pen to use when drawing in ghost mode.
        /// </summary>
        protected Pen PenGhost { get; set; } = Pens.Black;

        /// <summary>
        ///     The color to use for drawing.
        /// </summary>
        public Color Color
        {
            get { return Pen.Color; }
            set
            {
                Pen = new Pen(value);
                PenGhost = Pen;

                Brush = new SolidBrush(value);
                BrushGhost = Brush;
            }
        }

        /// <summary>
        ///     The x-coordinate of the center.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     The y-coordinate of the center.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     The x-coordinate of the center of the ghost.
        /// </summary>
        public int GhostX { get; set; }

        /// <summary>
        ///     The y-coordinate of the center of the ghost.
        /// </summary>
        public int GhostY { get; set; }

        /// <summary>
        ///     The width of this object.
        /// </summary>
        public abstract int Width { get; }

        /// <summary>
        ///     The height of this object.
        /// </summary>
        public abstract int Height { get; }

        /// <summary>
        ///     The name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The size of the name when it is drawn.
        /// </summary>
        protected Size TextSize => TextRenderer.MeasureText(Name, Font);

        /// <summary>
        ///     The x-coordinate of the left border.
        /// </summary>
        public int Left => (int) (X - Width/2f);

        /// <summary>
        ///     The x-coordinate of the right border.
        /// </summary>
        public int Right => (int) (X + Width/2f);

        /// <summary>
        ///     The y-coordinate of the top border.
        /// </summary>
        public int Top => (int) (Y - Height/2f);

        /// <summary>
        ///     The y-coordinate of the bottom border.
        /// </summary>
        public int Bottom => (int) (Y + Height/2f);

        /// <summary>
        ///     Checks if the given coordinates are within the borders of this object.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>Whether the given coordinates are within the borders of this object.</returns>
        public bool InSelection(int x, int y) => x >= Left && x <= Right && y >= Top && y <= Bottom;

        /// <summary>
        ///     Draws this object.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        public void Draw(Graphics g)
        {
            // Use the x- and y-coordinate as center
            g.TranslateTransform(-Width/2f, -Height/2f);

            DrawSelf(g);

            // Draw bounds
            if (MainForm.DrawBoundingBox)
            {
                g.DrawRectangle(Pen, X, Y, Width, Height);
            }

            // Translate back to original x- and y-coordinate
            g.TranslateTransform(Width/2f, Height/2f);
        }

        /// <summary>
        ///     Draws the ghost version of the object.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        public void DrawGhost(Graphics g)
        {
            // Use the x- and y-coordinate as center
            g.TranslateTransform(-Width/2f, -Height/2f);

            DrawSelfGhost(g, GhostX, GhostY);

            // Draw bounds
            if (MainForm.DrawBoundingBox)
            {
                g.DrawRectangle(Pen, X, Y, Width, Height);
            }

            // Translate back to original x- and y-coordinate
            g.TranslateTransform(Width/2f, Height/2f);
        }

        /// <summary>
        ///     Type specific implementation for drawing itself.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        protected abstract void DrawSelf(Graphics g);

        /// <summary>
        ///     Type specific implementation for drawing the ghost version of itself.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        protected abstract void DrawSelfGhost(Graphics g, int x, int y);

        /// <summary>
        ///     Show a dialog that allows for editing of this object.
        /// </summary>
        public virtual void Edit()
        {
            string name = Prompt.ShowDialog("Name:", "Edit " + Name);
            if (!name.Equals(string.Empty))
            {
                Name = name;
            }
        }

        /// <summary>
        ///     Sets the x- and y-coordinate.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">the y-coordinate.</param>
        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}