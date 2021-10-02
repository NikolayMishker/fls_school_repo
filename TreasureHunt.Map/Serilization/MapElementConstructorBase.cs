using System;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    public abstract class MapElementConstructorBase : IMapElementConstructor
    {
        public abstract ITreasureMapElement Construct(TreasureMapElementInfo elementInfo);

        protected bool ParsePointStrict(string[] tokens, out Point point)
        {
            point = new Point();

            if (tokens.Length != 3)
            {
                return false;
            }

            return ParsePoint(tokens, out point, 0);
        }

        protected bool ParsePoint(string[] tokens, out Point point, int startIndex)
        {
            point = new Point();

            if (tokens.Length < startIndex + 3 || tokens[startIndex + 1] != ",")
            {
                return false;
            }

            int x, y;

            if (int.TryParse(tokens[startIndex], out x) && int.TryParse(tokens[startIndex + 2], out y))
            {
                point = new Point(x, y);
                return true;
            }

            return false;
        }

        protected bool ParseRectangle(string[] tokens, out Rectangle rectangle)
        {
            rectangle = new Rectangle();

            if (tokens.Length != 7 || tokens[3] != ":")
            {
                return false;
            }

            Point p1, p2;

            if (ParsePoint(tokens, out p1, 0) && ParsePoint(tokens, out p2, 4))
            {
                try
                {
                    rectangle = new Rectangle(p1.X, p1.Y, p2.X, p2.Y);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }


        protected bool ParsePointsArray(string[] tokens, out Point[] points)
        {
            points = null;

            if (tokens.Length < 7 || (tokens.Length + 1) % 4 != 0)
            {
                return false;
            }

            var pointsCount = (tokens.Length + 1) / 4;
            var tempPoints = new Point[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                if (i < pointsCount - 1 && tokens[i * 4 + 3] != "->")
                {
                    return false;
                }

                Point p;
                if (!ParsePoint(tokens, out p, i * 4))
                {
                    return false;                        
                }

                tempPoints[i] = p;
            }

            points = tempPoints;
            return true;
        }
    }
}
