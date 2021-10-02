using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public class TreasureMap
    {
        private readonly List<ITreasureMapElement> treasureMapElements = new List<ITreasureMapElement>();

        public ICollection<ITreasureMapElement> Elements { get; private set; }

        public TreasureMap()
        {
            Elements = new ReadOnlyCollection<ITreasureMapElement>(treasureMapElements);
        }

        public void AddElement(ITreasureMapElement element)
        {
            treasureMapElements.Add(element);
        }

        public void Clear()
        {
            treasureMapElements.Clear();
        }

        public Rectangle? GetMapBounds()
        {
            var elementsCount = treasureMapElements.Count;

            if (elementsCount == 0)
            {
                return null;
            }

            var boundsRectangle = treasureMapElements[0].GetContainingRectangle();
            var x1 = boundsRectangle.X1;
            var x2 = boundsRectangle.X2;
            var y1 = boundsRectangle.Y1;
            var y2 = boundsRectangle.Y2;

            for (var i = 1; i < elementsCount; i++)
            {
                var recrangle = treasureMapElements[i].GetContainingRectangle();

                if (recrangle.X1 < x1)
                    x1 = recrangle.X1;
                if (recrangle.X2 > x2)
                    x2 = recrangle.X2;
                if (recrangle.Y1 < y1)
                    y1 = recrangle.Y1;
                if (recrangle.Y2 > y2)
                    y2 = recrangle.Y2;
            }

            return new Rectangle(x1, y1, x2, y2);
        }

        public void Render(IGraphics<IRasterMapElement> graphics)
        {
            foreach (var element in treasureMapElements)
            {
                element.Render(graphics);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var element in treasureMapElements)
            {
                builder.AppendLine(element.ToString());
            }

            return builder.ToString();
        }
    }
}
