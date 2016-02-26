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

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
