using System;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;


namespace TreasureHunt.Map.Rendering
{
    public class Graphics<TMapElement> : IGraphics<TMapElement>
    {
        private readonly IRasterMap<TMapElement> map;

        public Graphics(IRasterMap<TMapElement> map)
        {
            if (map == null)
            {
                throw new ArgumentNullException("map");
            }

            this.map = map;
        }

        public void PlaceLinearElement(Point p1, Point p2, TMapElement element)
        {
            if (p1.X > p2.X)
            {
                Point swap = p1;
                p1 = p2;
                p2 = swap;
            }

            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;

            if (dy == 0)
            {
                PlaceHorizontalLineElement(p1, p2.X, element);
                return;
            }

            if (dx == 0)
            {
                if (dy > 0)
                    PlaceVerticalLineElement(p1, p2.Y, element);
                else
                    PlaceVerticalLineElement(p2, p1.Y, element);
                return;
            }

            if (dx > Math.Abs(dy))
            {
                var ratio = ((double)dy) / dx;
                var step = 0;

                do
                {
                    var x = p1.X + step;
                    var y = (int)Math.Round(p1.Y + ratio * step);

                    PlaceElementXY(x, y, element);

                    step++;
                } while (step <= dx);
            }
            else 
            { 
              var ratio = ((double) dx/dy);
                var step = 0;
                var increment = Math.Sign(dy);

                do
                {
                    var y = p1.Y + step;
                    var x = (int)Math.Round(p1.X + ratio * step);
                    PlaceElementXY(x, y, element);
                    step += increment;
                } while (step * increment <= increment * dy);
            }
        }

        private void PlaceHorizontalLineElement(Point start, int endX, TMapElement element)
        {
            for (var x = start.X; x <= endX; x++)
                PlaceElementXY(x, start.Y, element);
        }

        private void PlaceVerticalLineElement(Point start, int endY, TMapElement element)
        {
            for (var y = start.Y; y <= endY; y++)
                PlaceElementXY(start.X, y, element);
        }

        public void PlaceRectangleElement(Rectangle rectangle, TMapElement element)
        {
            for (var x = rectangle.X1; x <= rectangle.X2; x++)
            { 
                for(var y = rectangle.Y1; y <= rectangle.Y2 ; y++)
                    PlaceElementXY(x, y, element);
            }
                
        }

        public void PlacePointElement(Point point, TMapElement element)
        {
            PlaceElementXY(point.X, point.Y, element);
        }

        private void PlaceElementXY(int x, int y, TMapElement element)
        {
            if (x < 0 || y < 0 || x >= map.Width || y >= map.Height)
                return;

            map[x, y] = element;
        }

    }

}
