using TreasureHunt.Common.Geometry;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    [MapElementConstructorRegistration(Bridge.Tag)]
    public class BridgeConstructor : MapElementConstructorBase
    {

        public override ITreasureMapElement Construct(TreasureMapElementInfo elementInfo)
        {
            Point point;
            var parseSucceeded = ParsePointStrict(elementInfo.Tokens, out point);
            if (parseSucceeded)
            {
                return new Bridge(point);
            }

            return null;
        }
    }
}
