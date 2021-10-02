using System;
using TreasureHunt.Common.Geometry;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.Map.VectorModels
{
    public class Treasure : SinglePointElement, IRasterMapElement
    {
        public const string Tag = "TREASURE";

        protected override string ElementName
        {
            get 
            {
                return Tag;
            }
        }

        public Treasure(Point location) : base(location)
        { }

        protected override IRasterMapElement GetRasterElement()
        {
            return this;
        }

        char IRasterMapElement.Image
        {
            get 
            {
                return '+';
            }
        }

        ConsoleColor IRasterMapElement.Color
        {
            get
            {
                return ConsoleColor.Yellow;
            }
        }
    }
}
