using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    public interface ITreasureMapElementsFactory
    {
        public ITreasureMapElement CreateMapElement(TreasureMapElementInfo elementInfo);
    }
}
