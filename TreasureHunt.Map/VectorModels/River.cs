using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public class River : IRasterMapElement, ITreasureMapElement
    {
        public const string Tag = "WATER";

        private readonly List<Point> points = new List<Point>();

        public ICollection<Point> Points { get; private set; }

        public River(ICollection<Point> points)
        {
            if (points == null || points.Count < 2)
            {
                throw new ArgumentException("For creating river need minimum 2 points");
            }

            this.points.AddRange(points);

            Points = new ReadOnlyCollection<Point>(this.points);

        }

        public Rectangle GetContainingRectangle()
        {
            var pointsCount = points.Count;

            if (pointsCount == 0)
            {
                throw new ArgumentException("River is empty");
            }

            int x1, x2, y1, y2;
            x1 = x2 = points[0].X;
            y1 = y2 = points[0].Y;

            for (int i = 1; i < pointsCount; i++)
            {
                var point = points[i];

                if (point.X < x1)
                    x1 = point.X;
                else if (point.X > x2)
                    x2 = point.X;

                if (point.Y < y1)
                    y1 = point.Y;
                else if (point.Y > y2)
                    y2 = point.Y;
            }

            return new Rectangle(x1, y1, x2, y2);
        }

        public void Render(IGraphics<IRasterMapElement> graphics)
        {
            for (var i = 1; i < points.Count; i++)
            {
                graphics.PlaceLinearElement(points[i - 1], points[i], (IRasterMapElement)this);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", Tag, string.Join(" -> ", points));
        }

        char IRasterMapElement.Image => '~';

        ConsoleColor IRasterMapElement.Color => ConsoleColor.DarkGreen;

    }
}
