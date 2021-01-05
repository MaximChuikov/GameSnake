using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Змейка
{
    static class Interface
    {
        public static int indent; //координата Х, с которой начинается строится прогрессная таблица
        public static void DrawMap()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int x = 0; x < indent; x++)
            {
                for (int y = 0; y < Game.Map.Length/(indent); y++)
                {
                    if(Game.Map[x, y] == '*')
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void DrawBar()
        {
            string stick = new string(' ', Game.win + 2);

            Console.BackgroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(indent, 0);
            Console.Write(stick);

            Console.SetCursorPosition(indent, 2);
            Console.Write(stick);

            Console.SetCursorPosition(indent, 1);
            Console.Write(' ');

            Console.SetCursorPosition(indent + Game.win + 1, 1);
            Console.Write(' ');
        }

        public static void DrawProgress()
        {
            string apples = new string('#', Game.apples);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(indent + 1, 1);
            Console.Write(apples);
        }
        
        public static void WinLose(bool result)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            string[] win =
            {
            "██╗░░░██╗░█████╗░██╗░░░██╗  ░██╗░░░░░░░██╗██╗███╗░░██╗",
            "╚██╗░██╔╝██╔══██╗██║░░░██║  ░██║░░██╗░░██║██║████╗░██║",
            "░╚████╔╝░██║░░██║██║░░░██║  ░╚██╗████╗██╔╝██║██╔██╗██║",
            "░░╚██╔╝░░██║░░██║██║░░░██║  ░░████╔═████║░██║██║╚████║",
            "░░░██║░░░╚█████╔╝╚██████╔╝  ░░╚██╔╝░╚██╔╝░██║██║░╚███║",
            "░░░╚═╝░░░░╚════╝░░╚═════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝"
            };
            string[] lose =
            {
                "██╗░░░██╗░█████╗░██╗░░░██╗  ██╗░░░░░░█████╗░░██████╗███████╗",
                "╚██╗░██╔╝██╔══██╗██║░░░██║  ██║░░░░░██╔══██╗██╔════╝██╔════╝",
                "░╚████╔╝░██║░░██║██║░░░██║  ██║░░░░░██║░░██║╚█████╗░█████╗░░",
                "░░╚██╔╝░░██║░░██║██║░░░██║  ██║░░░░░██║░░██║░╚═══██╗██╔══╝░░",
                "░░░██║░░░╚█████╔╝╚██████╔╝  ███████╗╚█████╔╝██████╔╝███████╗",
                "░░░╚═╝░░░░╚════╝░░╚═════╝░  ╚══════╝░╚════╝░╚═════╝░╚══════╝"
            };

            string[] array;

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                array = win;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                array = lose;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.SetCursorPosition(indent, i + 3);
                Console.Write(array[i]);
            }
        }

        public static void Beep()
        {
            bool result = !(Game.apples < Game.win);
            int[] sounds = { 400, 450, 500, 550, 600, 650, 700, 800, 900, 1000 };

            if (result)
            {
                for (int i = 0; i < sounds.Length; i++)
                {
                    Console.Beep(sounds[i], 400);
                }
            }
            else
            {
                for (int i = sounds.Length - 1; i >= 0; i--)
                {
                    Console.Beep(sounds[i], 400);
                }
            }
        }
    }
}
