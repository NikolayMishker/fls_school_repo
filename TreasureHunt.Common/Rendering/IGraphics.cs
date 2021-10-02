using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Common.Geometry;

namespace TreasureHunt.Common.Rendering
{
    public interface IGraphics<IRasterMapElement>
    {
        public void PlaceLinearElement(Point p1, Point p2, IRasterMapElement element);

        public void PlacePointElement(Point point, IRasterMapElement element);

        public void PlaceRectangleElement(Rectangle rectangle, IRasterMapElement element);
    }
}
