namespace TreasureHunt.Common.Geometry
{
    public class Point
    {
        private readonly int x, y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
        }

        public override string ToString()
        {
            return string.Concat(X, ", ", Y);
        }
    } 
}
