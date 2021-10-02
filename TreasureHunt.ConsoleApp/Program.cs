using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Common.Rendering;
using TreasureHunt.Map.Rendering;
using TreasureHunt.Map.Serilization;
using TreasureHunt.Map.VectorModels;


namespace TreasureHunt.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = ProcessArgs(args);
            if (fileName == null)
            {
                return;
            }

            TreasureMap treasureMap = null;
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    var treasureMapReader = new TreasureMapReader(stream);
                    var elementsFactory = InitializeMapElementsFactory();

                    treasureMap = treasureMapReader.ReadMap(elementsFactory);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Unable to read and parse treasure map file {fileName}");
                Console.WriteLine("Below is the complete information:");
                Console.WriteLine(exception);
                return;
            }

            var mapBounds = treasureMap.GetMapBounds();
            if (mapBounds == null)
            {
                Console.WriteLine("Map is empty");
                return;
            }

            var consoleMap = new ConsoleMap(mapBounds.X2 + 1, mapBounds.Y2 + 1);

            var graphics = new Graphics<IRasterMapElement>(consoleMap);

            treasureMap.Render(graphics);

            consoleMap.InitializeConsole();
            consoleMap.DrawBuffer();

            Console.ReadKey();
        }


        private static string ProcessArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine($"Expected 1 parametr, actual - {args.Length}");
                return null;
            }

            var fileName = args[0];
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File with name {fileName} not found");
                return null;
            }

            return fileName;
        }

        private static TreasureMapElementsFactory InitializeMapElementsFactory()
        {
            return new TreasureMapElementsFactory(true);
        }
    }
}
