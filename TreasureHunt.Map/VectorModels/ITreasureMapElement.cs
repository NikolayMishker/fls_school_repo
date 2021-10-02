using System;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public interface ITreasureMapElement
    {
        Rectangle GetContainingRectangle();
        void Render(IGraphics<IRasterMapElement> graphics);
    }
}
