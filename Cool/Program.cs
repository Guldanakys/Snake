using Cool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cool
{
    class Program
    {
        public static int TmCount;
        public static string dir = "Right";


        static void MoveTime(object state)// сам таймер(действие)
        {
            TmCount++;

            
            if (Console.KeyAvailable) { 
            //обозначаем нажатие клавиш
            ConsoleKeyInfo pressedKey = Console.ReadKey();//чтение клавиш
                

                switch (pressedKey.Key)// меняем направление
            {
                case ConsoleKey.UpArrow:
                        dir = "Up";
                    break;
                case ConsoleKey.DownArrow:
                        dir = "Down";
                    break;
                case ConsoleKey.LeftArrow:
                        dir = "Left";
                        break;
                case ConsoleKey.RightArrow:
                        dir = "Right";
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
            
            switch (dir)// меняем положение
            {
                case "Up":
                    Game.snake.Move(0, -1);
                    break;
                case "Down":
                    Game.snake.Move(0, 1);
                    break;
                case "Left":
                    Game.snake.Move(-1, 0);
                    break;
                case "Right":
                    Game.snake.Move(1, 0);
                    break;

            }
            if (Game.inGame)
            {
                Game.Redraw();
            }
            else {
                Console.Clear();
                Console.SetCursorPosition(35, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game Over!");    
            }
            
        }
        static void Main(string[] args)
        {

            Game.inGame = true;
            // загружаем уровень 1
            Game.LoadLevel(1);
            Game.Init();
            // определяем размер игрового поля
            Console.SetWindowSize(48, 48);


            Timer tm = new Timer(new TimerCallback(MoveTime));// создание таймера
            tm.Change(10, 100);

            Game.wall.Draw();// убираем мерцание стены
            while (Game.inGame)
            {
                
            }
            tm.Dispose();
            


            Console.ReadKey();
        }
        
    }
}

//2 версия
//Используем дэйттайм
//namespace Cool
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            Game.inGame = true;
//            // загружаем уровень 1
//            Game.LoadLevel(1);
//            Game.Init();
//            // определяем размер игрового поля
//            Console.SetWindowSize(48, 48);

//            DateTime nextCheck = DateTime.Now.AddMilliseconds(100);

//            ConsoleKeyInfo pressedKey;
//            string dir = "Down";

//            Game.wall.Draw();// убираем мерцание стены
//            while (Game.inGame)
//            {
//                Game.time++;

//                Game.Redraw();
//                // обозначаем нажатие клавиш
//                //ConsoleKeyInfo pressedKey = Console.ReadKey();


//                while (nextCheck > DateTime.Now)
//                {
//                    //ответ клавиш если доступен
//                    if (Console.KeyAvailable)
//                    {
//                        pressedKey = Console.ReadKey(true);
//                        switch (pressedKey.Key)
//                        {
//                            case ConsoleKey.UpArrow:
//                                dir = "Up";
//                                break;
//                            case ConsoleKey.DownArrow:
//                                dir = "Down";
//                                break;
//                            case ConsoleKey.LeftArrow:
//                                dir = "Left";
//                                break;
//                            case ConsoleKey.RightArrow:
//                                dir = "Right";
//                                break;

//                        }
//                    }
//                }

//                //движение поменять направление
//                switch (dir)
//                {
//                    case "Up":
//                        Game.snake.Move(0, -1);
//                        break;
//                    case "Down":
//                        Game.snake.Move(0, 1);
//                        break;
//                    case "Left":
//                        Game.snake.Move(-1, 0);
//                        break;
//                    case "Right":
//                        Game.snake.Move(1, 0);
//                        break;

//                }
//                nextCheck = DateTime.Now.AddMilliseconds(100);
//            }

//            Console.ReadKey();
//        }

//    }
//}

