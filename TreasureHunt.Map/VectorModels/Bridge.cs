using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public class Bridge : SinglePointElement, IRasterMapElement
    {
        public const string Tag = "BRIDGE";

        public Bridge(Point location) : base(location)
        {
        }

        protected override string ElementName
        {
            get 
            {
                return Tag;
            }
        }

        protected override IRasterMapElement GetRasterElement()
        {
            return this;
        }

        char IRasterMapElement.Image => '#';

        ConsoleColor IRasterMapElement.Color => ConsoleColor.DarkGreen;
    }
}
