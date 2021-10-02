using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Common.Rendering
{
    public interface IRasterMapElement
    {
        char Image { get; }
        ConsoleColor Color { get; }
    }
}
