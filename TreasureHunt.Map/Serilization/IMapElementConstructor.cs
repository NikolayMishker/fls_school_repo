using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    public interface IMapElementConstructor
    {
        public ITreasureMapElement Construct(TreasureMapElementInfo elementInfo);
    }
}
