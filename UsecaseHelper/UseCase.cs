using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UsecaseHelper
{
    /// <summary>
    ///     Represents a use case that can have actors linked to it.
    /// </summary>
    public class UseCase : Drawable
    {
        /// <summary>
        ///     A short summary describing this use case.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        ///     The actors that are linked to this use case.
        /// </summary>
        public List<Actor> Actors { get; } = new List<Actor>();

        /// <summary>
        ///     The pre-conditions for this use case.
        /// </summary>
        public string Assumptions { get; set; }

        /// <summary>
        ///     A longer description of this use case.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     The exceptions this use case can "throw".
        /// </summary>
        public string Exceptions { get; set; }

        /// <summary>
        ///     The result that will be accomplished by this use case.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        ///     The width of this use case, depending on the length of its name.
        /// </summary>
        public override int Width => TextSize.Width + 25;

        /// <summary>
        ///     The height of this use case, depending on the height of its name.
        /// </summary>
        public override int Height => TextSize.Height + 25;

        protected override void DrawSelf(Graphics g)
        {
            DrawSelf(g, Pen, Brush, X, Y);
        }

        protected override void DrawSelfGhost(Graphics g, int x, int y)
        {
            DrawSelf(g, PenGhost, BrushGhost, x, y);
        }

        /// <summary>
        ///     Draws this use case.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        /// <param name="pen">The pen to use for drawing.</param>
        /// <param name="brush">The brush to use for drawing.</param>
        /// <param name="x">The x-coordinate of the top left corner.</param>
        /// <param name="y">The y-coordinate of the top left corner.</param>
        private void DrawSelf(Graphics g, Pen pen, Brush brush, int x, int y)
        {
            // Draw border
            g.DrawEllipse(pen, x, y, Width, Height);

            // Draw name
            g.DrawString(Name, Font, brush, x + Width/2 - TextSize.Width/2, y + Height/2 - TextSize.Height/2);

            // Draw lines to all actors
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

        /// <summary>
        ///     Shows a <see cref="UseCaseForm" /> that allows for editing of this object.
        /// </summary>
        public override void Edit()
        {
            // Populate dialog
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

            // Show dialog
            if (useCaseForm.ShowDialog() == DialogResult.OK)
            {
                // Get input from dialog
                Name = useCaseForm.CaseName;
                Assumptions = useCaseForm.Assumptions;
                Description = useCaseForm.Description;
                Exceptions = useCaseForm.Exceptions;
                Result = useCaseForm.Result;
                Summary = useCaseForm.Summary;
            }
        }

        public override string ToString() => Name;
    }
}