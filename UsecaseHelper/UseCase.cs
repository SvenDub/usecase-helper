using System;
using System.Collections.Generic;
using System.Drawing;

namespace UsecaseHelper
{
    public class UseCase : Drawable
    {
        public string Summary { get; set; }
        public List<Actor> Actors { get; } = new List<Actor>(); 
        public string Assumptions { get; set; }
        public string Description { get; set; }
        public string Exceptions { get; set; }
        public string Result { get; set; }

        private readonly Pen _pen = Pens.Black;
        private readonly Brush _brush = Brushes.Black;

        public UseCase()
        {
            Width = 100;
            Height = 25;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(_pen, X, Y, Width, Height);
            g.DrawString(Name, new Font(FontFamily.GenericMonospace, 10), _brush, new RectangleF(X, Y + Height, 100, 50));

            Actors.ForEach(actor => g.DrawLine(_pen, X, Y, actor.X, actor.Y));
        }
    }
}
