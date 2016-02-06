using Cool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool
{
    class Program
    {
        static void Main(string[] args)
        {

            Game.inGame = true;
            // загружаем уровень 1
            Game.LoadLevel(1);
            Game.Init();
            // определяем размер игрового поля
            Console.SetWindowSize(48, 48);

            while (Game.inGame)
            {
                Game.Redraw();
                // обозначаем нажатие клавиш
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.inGame = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }

            Console.ReadKey();
        }

    }
}
