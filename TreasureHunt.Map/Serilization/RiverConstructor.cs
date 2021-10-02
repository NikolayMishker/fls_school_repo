using TreasureHunt.Common.Geometry;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    [MapElementConstructorRegistration(River.Tag)]
    public class RiverConstructor : MapElementConstructorBase
    {
        public override ITreasureMapElement Construct(TreasureMapElementInfo elementInfo)
        {
            Point[] points;
            var parseSucceeded = ParsePointsArray(elementInfo.Tokens, out points);
            if (parseSucceeded)
            {
                return new River(points);
            }

            return null;
        }
    }
}
