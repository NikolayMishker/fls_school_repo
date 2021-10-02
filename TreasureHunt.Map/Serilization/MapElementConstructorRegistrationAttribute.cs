using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Map.Serilization
{
    public class MapElementConstructorRegistration : Attribute
    {
        public string Tag { get; set; }

        public MapElementConstructorRegistration(string tag)
        {
            Tag = tag;
        }
    }
}
