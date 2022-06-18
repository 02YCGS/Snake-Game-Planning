using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_Planning
{
    internal class Map
    {
        Graphics g;
        public Point mapLeft;
        //每个蛇块的长度
        public static int unit = 15;
        //定义地图的长度
        public readonly int length = 30 * unit;
        //定义地图的宽度
        public readonly int width = 25 * unit;
        //定义初始分数
        public int score = 0;
        public readonly Snake snake;
        public bool victory = false;
        public Snake Snake
        {
            get { return snake; }
        }

        Food food;

        public Map(Point start,Graphics g) 
        {
            this.g = g;
            mapLeft = start;
            snake = new Snake(start, 5);
            food = new Food(g);
            food.Location = new Point(start.X + 30, start.Y + 30);
        }
        /// <summary>
        /// 随机产生食物
        /// </summary>
        /// <returns></returns>
        private Food FoodRandom(Graphics g)
        {
            Random random = new Random();
            int x = random.Next(0,length / unit);
            int y = random.Next(0,width / unit);
            Point Location = new Point(mapLeft.X + x * 15, mapLeft.Y + y * 15);
            Food food = new Food(g);
            food._Location = Location;
            return food;
        }
        /// <summary>
        /// 重新画食物
        /// </summary>
        /// <param name="g"></param>
        public void DrawNewFood(Graphics g)
        {
                //消除原先食物
                food.DeleteFood(g);
                //产生随机位置的食物
                food = FoodRandom(g);
                //显示食物
                food.DrawFood(g);
        }
        /// <summary>
        /// 判断是否吃到了食物
        /// </summary>
        /// <returns></returns>
        public bool CheckFood() 
        {
            return food.Location.Equals(snake.HeadPoint);
        }
        /// <summary>
        /// 画地图
        /// </summary>
        /// <param name="g"></param>
        public void DrawMap(Graphics g)
        {
            //画出地图的框
            g.DrawRectangle(new Pen(Color.Blue), mapLeft.X, mapLeft.Y, length, width);
            //显示食物 
            food.DrawFood(g);
            if (CheckFood())
            {
                //当吃到一个食物后随机产生下一个食物
                DrawNewFood(g);
                //蛇变长
                snake.SnakeGrowth();
                //分数增加
                score += 10;
                //if (score >= 100)
                //{
                //    victory = true;
                //}
                //显示蛇
                snake.ShowSnake(g);
            }
            else
            {
                snake.Go(g);
                snake.ShowSnake(g);
            }
        }

        /// <summary>
        /// 判断蛇是否碰到墙壁
        /// </summary>
        /// <returns></returns>
        public bool CheckSnake() 
        {
            return !(snake.getHeadPoint.X > mapLeft.X - 5 && snake.getHeadPoint.X < (mapLeft.X + length - 5) && snake.getHeadPoint.Y > mapLeft.Y - 5 && snake.getHeadPoint.Y < (mapLeft.Y + width - 5));
        }

    }
}
