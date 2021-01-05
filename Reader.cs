using System;
using System.IO;
using System.Collections.Generic;

namespace Змейка
{
    static class Reader
    {
        static string path = Environment.CurrentDirectory + "/config.txt";
        public static void Read()
        {
            string[] note = File.ReadAllLines(path);
            Direction.dir = note[0][0];
            Game.time = Int32.Parse(note[1].Trim(' '));
            Game.win = Int32.Parse(note[2].Trim(' '));
            Interface.indent = note[3].Length;
            
            List<string> map = new List<string>();
            for (int i = 3; i < note.Length; i++)
            {
                map.Add(note[i].Trim(' '));
            }

            Game.Map = new char[note[3].Length, map.Count];
            Game.Snake = new char[note[3].Length, map.Count];

            for (int x = 0; x < note[3].Length; x++)
            {
                for (int y = 0; y < map.Count; y++)
                {
                    if (map[y][x] == '*')
                        Game.Map[x, y] = map[y][x];
                    else
                        Game.Map[x, y] = ' ';

                    if (map[y][x] == 'H')
                    {
                        Game.Head.x = x;
                        Game.Head.y = y;
                    }

                    if (map[y][x] == '-' || map[y][x] == 'H')
                        Game.Map[x, y] = '-';

                    Game.Snake[x, y] = ' ';
                }
            }
        }

    }
}
