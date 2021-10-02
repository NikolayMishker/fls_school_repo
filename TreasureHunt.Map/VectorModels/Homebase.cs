using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public class Homebase : ITreasureMapElement, IRasterMapElement
    {
        public const string Tag = "BASE";

        public Rectangle Disposition { get; private set; }

        public Homebase(Rectangle disposition)
        {
            Disposition = disposition;
        }

        public Rectangle GetContainingRectangle()
        {
            return Disposition;
        }

        public void Render(IGraphics<IRasterMapElement> graphics)
        {
            graphics.PlaceRectangleElement(Disposition, this);
        }

        public override string ToString()
        {
            return string.Concat(Tag, "(", Disposition, ")"); 
        }

        char IRasterMapElement.Image { get { return '@'; } }

        ConsoleColor IRasterMapElement.Color
        {
            get
            {
                return ConsoleColor.Green;
            }
        }
    }
}
