using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool.Models
{
    public class Game
    {
        // определяем главные составные части игры
        //public static int speed;
        public static int levelNum = 1;
        public static int foodEaten = 0;
        public static bool inGame;
        public static Snake snake = new Snake();
        public static Wall wall = new Wall();
        public static Food food = new Food();

        public static void Redraw()
        {
            // очищаем и рисуем объекты
            //Console.Clear();
            snake.Draw();
            food.Draw();
            //wall.Draw();
            // очки и уровни
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, 28);
            Console.WriteLine("SCORES : " + Game.foodEaten);
            Console.SetCursorPosition(20, 30);
            Console.WriteLine("LEVEL - " + Game.levelNum);
            Console.SetCursorPosition(20, 32);
            Console.WriteLine("In Game: " + Program.TmCount / 10 + " s");
            
        }

        public static void LoadLevel(int i)
        {
            // выставляем поле
            FileStream fs = new FileStream(string.Format(@"C:\Users\home pc\Desktop\Программинг\LevelWall{0}.txt", i),
                FileMode.Open, FileAccess.Read);
            
            StreamReader reader = new StreamReader(fs);

            

            string line;
            int row = -1;
            int col = 0;

            while ((line = reader.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        Game.wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            fs.Close();
        }
        // определяем параметры сохранения
        public static void Resume()
        {
            wall.Resume();
            food.Resume();
            snake.Resume();
        }

        public static void Save()
        {
            wall.Save();
            food.Save();
            snake.Save();
        }

        public static void Init()
        {
            snake.body.Add(new Point { x = 10, y = 10 });
            food.body.Add(new Point { x = 20, y = 10 });
        }
    }
}
