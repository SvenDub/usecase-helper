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
            DrawSelf(g, _pen, _brush, X, Y);
        }

        protected override void DrawSelfGhost(Graphics g, int x, int y)
        {
            DrawSelf(g, _penGhost, _brushGhost, x, y);
        }

        private void DrawSelf(Graphics g, Pen pen, Brush brush, int x, int y)
        {
            g.DrawEllipse(pen, x, y, Width, Height);

            g.DrawString(Name, _font, brush, x + Width/2 - TextSize.Width/2, y + Height/2 - TextSize.Height/2);

            Actors.ForEach(actor =>
            {
                int targetX = actor.X + Width/2;
                int targetY = actor.Y + Height/2;

                if (actor == MainForm.SelectedDrawable)
                {
                    targetX = actor.GhostX + Width/2;
                    targetY = actor.GhostY + Height/2;
                }

                g.DrawLine(pen, x + Width/2, y + Height/2, targetX, targetY);
            });
        }

        public override void Edit()
        {
            UseCaseForm useCaseForm = new UseCaseForm
            {
                CaseName = Name,
                Assumptions = Assumptions,
                Description = Description,
                Exceptions = Exceptions,
                Result = Result,
                Summary = Summary,
                Actors = Actors
            };

            useCaseForm.ShowDialog();

            Name = useCaseForm.CaseName;
            Assumptions = useCaseForm.Assumptions;
            Description = useCaseForm.Description;
            Exceptions = useCaseForm.Exceptions;
            Result = useCaseForm.Result;
            Summary = useCaseForm.Summary;
        }

        public override string ToString() => Name;
    }
}