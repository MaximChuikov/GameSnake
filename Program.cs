using System;
using System.IO;
using System.Threading;

namespace Змейка
{
    class Program
    {
        static void Main()
        {
            Console.SetBufferSize(500, 300);
            Reader.Read();
            Interface.DrawMap();
            Interface.DrawBar();
            Game.Start();
        }
    }
}
