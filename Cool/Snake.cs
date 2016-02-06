using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool.Models
{
    public class Snake : Drawer
    {
        Point head = new Point();
        public void Eat() { }
        public Snake()
        {
            color = ConsoleColor.Yellow;
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (body[0].x + dx < 0) dx = dx + 48;
            if (body[0].y + dy < 0) dy = dy + 48;
            if (body[0].x + dx > 48) dx = dx - 48;
            if (body[0].y + dy > 48) dy = dy - 48;

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            //проверка, можем ли скушать
            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            {
                //добавил к змейке новую точку. прирост
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });
                
                // переместил еду на новую позицию 
                int tx = 0, ty = 0;
                bool success = false;
                while (!success)
                {
                    tx = new Random().Next(0, 49);
                    ty = new Random().Next(0, 49);
                    Game.food.body[0].x = new Random().Next(0, 49);
                    Game.food.body[0].y = new Random().Next(0, 49);
                    success = true;
                    for (int i = 0; i < Game.wall.body.Count; ++i)
                    {
                        if (tx == Game.wall.body[i].x && ty == Game.wall.body[i].y)
                        {
                            success = false;
                            break;
                        }
                    }
                    for (int i = 0; i < Game.snake.body.Count; ++i)
                    {
                        if (tx == Game.snake.body[i].x && ty == Game.snake.body[i].y)
                        {
                            success = false;
                            break;
                        }
                    }

                }
                Game.food.body[0].x = tx;
                Game.food.body[0].y = ty;

                Game.foodEaten++;
                if (Game.foodEaten % 4 == 0)
                {
                    Console.Clear();
                    Game.levelNum++;
                    Game.wall.body.Clear();
                    Game.food.body.Clear();

                    Game.LoadLevel((Game.foodEaten / 4) + 1);
                    Game.Init();
                }
            }
            
            //проверка, есть ли столкновение со стеной
            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(35, 15);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    Game.inGame = false;
                }
            }
        }
    }
}

