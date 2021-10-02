using TreasureHunt.Common.Geometry;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    [MapElementConstructorRegistration(Treasure.Tag)]
    public class TreasureConstructor : MapElementConstructorBase
    {
        public override ITreasureMapElement Construct(TreasureMapElementInfo elementInfo)
        {
            Point point;
            var parseSucceeded = ParsePointStrict(elementInfo.Tokens, out point);
            if (parseSucceeded)
            {
                return new Treasure(point);
            }

            return null;
        }
    }
}
