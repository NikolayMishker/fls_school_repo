using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    public class TreasureMapElementsFactory : ITreasureMapElementsFactory
    {
        private readonly Dictionary<string, IMapElementConstructor> elementConstructors =
            new Dictionary<string, IMapElementConstructor>(StringComparer.InvariantCultureIgnoreCase);

        public TreasureMapElementsFactory(bool scanForExistingConstructors = false)
        {
            if (!scanForExistingConstructors)
                return;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var assemblyClasses = assembly.GetTypes().Where(type =>
                    type.IsClass && !type.IsGenericTypeDefinition && !type.IsAbstract);

                foreach (var type in assemblyClasses)
                {
                    var constructorAttribute = type.GetCustomAttribute<MapElementConstructorRegistration>();
                    if (constructorAttribute == null)
                        continue;

                    RegisterMapElementConstructor(constructorAttribute.Tag, (IMapElementConstructor)Activator.CreateInstance(type, null));
                }
            }
        }

        public void RegisterMapElementConstructor(string tag, IMapElementConstructor constructor)
        {
            elementConstructors[tag] = constructor;
        }

        public ITreasureMapElement CreateMapElement(TreasureMapElementInfo elementInfo)
        {
            if (!elementConstructors.ContainsKey(elementInfo.Name))
                return null;

            var constructor = elementConstructors[elementInfo.Name];
            return constructor.Construct(elementInfo);
        }
    }
}
