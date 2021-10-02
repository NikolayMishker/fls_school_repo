using TreasureHunt.Common.Geometry;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    [MapElementConstructorRegistration(Homebase.Tag)]
    public class HomebaseConstructor : MapElementConstructorBase
    {
        public override ITreasureMapElement Construct(TreasureMapElementInfo elementInfo)
        {
            Rectangle rectangle;
            var parseSucceeded = ParseRectangle(elementInfo.Tokens, out rectangle);
            if (parseSucceeded)
            {
                return new Homebase(rectangle);
            }

            return null;
        }
    }
}
