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

        public override int Width => TextSize.Width + 25;
        public override int Height => TextSize.Height + 25;

        protected override void DrawSelf(Graphics g)
        {
            g.DrawEllipse(_pen, X, Y, Width, Height);

            g.DrawString(Name, _font, _brush, X + (Width / 2) - (TextSize.Width / 2), Y + (Height / 2) - (TextSize.Height / 2));

            Actors.ForEach(actor => g.DrawLine(_pen, X + Width / 2, Y + Height / 2, actor.X + Width/2, actor.Y + Height/2));
        }
    }
}
