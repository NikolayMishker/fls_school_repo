using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public abstract class SinglePointElement : ITreasureMapElement
    {

        protected abstract string ElementName { get; }

        public Point Location { get; }

        protected SinglePointElement(Point location)
        {
            Location = location;
        }

        public Rectangle GetContainingRectangle()
        {
            return new Rectangle(Location.X, Location.Y, Location.X, Location.Y);
        }

        public void Render(IGraphics<IRasterMapElement> graphics)
        {
            graphics.PlacePointElement(Location, GetRasterElement());
        }

        protected abstract IRasterMapElement GetRasterElement();

        public override string ToString()
        {
            return string.Concat(ElementName, "(", Location, ")");
        }
    }
}
