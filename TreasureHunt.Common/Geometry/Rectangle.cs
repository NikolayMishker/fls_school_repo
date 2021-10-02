using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Common.Geometry
{
    public class Rectangle
    {
        private readonly int x1, y1, x2, y2;

        public int X1
        {
            get 
            {
                return x1;
            }
        }

        public int X2
        {
            get
            {
                return x2;
            }
        }

        public int Y1
        {
            get
            {
                return y1;
            }
        }

        public int Y2
        {
            get
            {
                return y2;
            }
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x1 < x2)
            {
                this.x1 = x1;
                this.x2 = x2;
            }
            else
            {
                this.x1 = x2;
                this.x2 = x1;
            }

            if (y1 < y2)
            {
                this.y1 = y1;
                this.y2 = y2;
            }
            else
            {
                this.y1 = y2;
                this.y2 = y1;
            }
        }

        public Rectangle()
        {
        }
    }
}
