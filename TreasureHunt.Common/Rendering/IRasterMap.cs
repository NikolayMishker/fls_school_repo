using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Common.Rendering
{
    public interface IRasterMap<TMapElement>
    {
        TMapElement this[int x, int y] { get; set; }

        int Width { get; }

        int Height { get; }
    }
}
