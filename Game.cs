using System;
using System.Threading;

namespace Змейка
{
    static class Game
    {
        static Random rand = new Random();

        public static bool Inversor = false;

        public static char[,] Map;
        public static char[,] Snake;
        public static int apples = 0;
        public static int win;
        private static Coordinate Apple = new Coordinate();
        public static Coordinate Head = new Coordinate();
        private static Coordinate LastHead = new Coordinate();
        private static Coordinate Tail = new Coordinate();
        public static char lastDir;
        public static int time;
        public static void Start()
        {
            Thread apple = new Thread(CreateApple);
            apple.Start();

            Coordinate copy = new Coordinate();

            Tail.x = Head.x;
            Tail.y = Head.y;
            LastHead.x = Head.x;
            LastHead.y = Head.y;
            DrawErase(true);
            Head.NextCord();
            DrawErase(true);
            Thread.Sleep(100);
            Inversor = !Inversor;

            while (apples < win)
            {
                Key();


                copy.x = Head.x;
                copy.y = Head.y;
                copy.NextCord();
                if (copy.GetChar() == '*' || (Snake[copy.x, copy.y] != ' ' && !(Tail.x == copy.x && Tail.y == copy.y)))
                    break;
                
                LastHead.x = Head.x;
                LastHead.y = Head.y;
                Head.NextCord();
                

                if (Head.x == Apple.x && Head.y == Apple.y)
                {
                    apples++;
                    Inversor = !Inversor;
                    Interface.DrawProgress();
                }
                else
                {
                    DrawErase(false);
                }

                DrawErase(true);
            }
            apple.Suspend();
            Thread sound = new Thread(Interface.Beep);
            sound.Start();
            Interface.WinLose(!(apples < win));
            Stop();

        }
        
        static void Key()
        {
            Coordinate copy = new Coordinate();
            int perTime = time/5;

            for (int i = 0; i < time / perTime ; i++ )
            {
                ConsoleKeyInfo key;
                if (Console.KeyAvailable) //изменение направления змеи
                {
                    Console.SetCursorPosition(Head.x, Head.y);
                    key = Console.ReadKey();
                    Console.SetCursorPosition(Head.x, Head.y);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(' ');

                    lastDir = Direction.dir;
                    Direction.SetDirection(key.Key);

                    copy.x = Head.x;
                    copy.y = Head.y;
                    copy.NextCord();

                    if (copy.x == LastHead.x && copy.y == LastHead.y) //предохранитель хода назад
                        Direction.dir = lastDir;


                    Thread.Sleep(time - (i * perTime));
                    break;
                }
                else
                    Thread.Sleep(perTime);
            }
                
            
        }

        static void Stop()
        {
            for (int i = 0; i < 7; i++)
            {
                Thread.Sleep(600);
                if (i % 2 == 0)
                    Console.BackgroundColor = ConsoleColor.Cyan;
                else
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(Head.x, Head.y);
                Console.Write(' ');
            }


        }

        static void CreateApple()
        {
            bool check = false;
            bool doing = !Inversor;
            for (; ; )
            {
                if (doing == Inversor)
                {
                    doing = !doing;
                    Apple.x = 0;
                    Apple.y = 0;
                    Coordinate cord = new Coordinate();
                    Thread.Sleep(rand.Next(1000, 3000));
                    do
                    {
                        cord.x = rand.Next(0, Interface.indent);
                        cord.y = rand.Next(0, Map.Length / Interface.indent);
                        check = ((cord.GetChar() == '-' || cord.GetChar() == 'H') && Snake[cord.x, cord.y] == ' ' 
                            && Math.Abs(cord.x-Head.x)>1 && Math.Abs(cord.y - Head.y) > 1);
                    } while (!check);
                    Apple.x = cord.x;
                    Apple.y = cord.y;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(Apple.x, Apple.y);
                    Console.Write(' ');
                }
                Thread.Sleep(300);
            }
        }

        static void DrawErase(bool drawTrue)
        {
            if (drawTrue)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Snake[LastHead.x, LastHead.y] = Direction.dir;
                Console.SetCursorPosition(Head.x, Head.y);
                Console.Write(' ');
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                char nowDir = Direction.dir;
                Direction.dir = Snake[Tail.x, Tail.y];
                Console.SetCursorPosition(Tail.x, Tail.y);
                Console.Write(' ');

                Snake[Tail.x, Tail.y] = ' ';
                Tail = Tail.NextCord();
                Direction.dir = nowDir;
            }
        }
        

        
        
        
    }
}
