using System;
using TreasureHunt.Common.Rendering;

namespace TreasureHunt.App
{
    public class ConsoleMap : IRasterMap<IRasterMapElement>
    {

        public IRasterMapElement this[int x, int y]
        {
            get { return buffer[y][x]; }
            set { buffer[y][x] = value; }
        }

        public int Width { get; }
        public int Height { get; }

        private IRasterMapElement[][] buffer;

        public ConsoleMap(int width, int height)
        {
            Width = width;
            Height = height;

            buffer = AllocateBuffer(Width, Height);
        }

        private IRasterMapElement[][] AllocateBuffer(int width, int height)
        {
            var tempBuffer = new IRasterMapElement[height][];
            for (var row = 0; row < height; row++)
            {
                tempBuffer[row] = new IRasterMapElement[width];
            }

            return tempBuffer;
        }

        public void InitializeConsole()
        {
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width + 10, Height + 10);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
        }

        public void DrawBuffer()
        {
            var i = 0;
            foreach (var row in buffer)
            {
                Console.SetCursorPosition(0, i++);
                foreach (var element in row)
                {
                    Console.ForegroundColor = element != null ? element.Color : ConsoleColor.Red;
                    Console.Write(element != null ? element.Image : '\u00B7');
                }
            }
        }


    }
}
