using System;

namespace Змейка
{
    static class Direction
    {
        public static char dir;
        public static Coordinate NextCord(this Coordinate cord)
        {
            switch(dir)
            {
                case 'l':
                    cord.x--;
                    break;
                case 'r':
                    cord.x++;
                    break;
                case 'u':
                    cord.y--;
                    break;
                case 'd':
                    cord.y++;
                    break;
            }

            return cord;
        }
        public static char GetChar(this Coordinate cord)
        {
            return Game.Map[cord.x,cord.y];
        }

        public static void SetDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    dir = 'l';
                    break;
                case ConsoleKey.DownArrow:
                    dir = 'd';
                    break;
                case ConsoleKey.RightArrow:
                    dir = 'r';
                    break;
                case ConsoleKey.UpArrow:
                    dir = 'u';
                    break;
                default:
                    break;

            }
        }
    }
}
