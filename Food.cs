using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game_Planning
{
    internal class Food
    {
        Graphics g;
        public Point Location;
        public Map map;

        public Food(Map map) 
        {
            this.g = map.g;
            this.map = map;
        }

        public Point _Location
        {
            set { Location = value; }
            get { return Location; }
        }
        /// <summary>
        /// 画食物
        /// </summary>
        /// <param name="g"></param>
        public void DrawFood() 
        {
            g.FillEllipse(
                new SolidBrush(Color.Red),
                Location.X * map.unit,
                Location.Y * map.unit,
                map.unit, map.unit
                );
        }
        /// <summary>
        /// 随机产生食物
        /// </summary>
        /// <returns></returns>
        public void FoodRandom()
        {
            Random random = new Random();
            int x = random.Next(0, map.column);
            int y = random.Next(0, map.row);
            Location = new Point(x, y);
            if (map.snake.CheckSnake(Location))
            {
                FoodRandom();
            }
        }
        /// <summary>
        /// 画食物
        /// </summary>
        /// <param name="g"></param>
        public void DrawNewFood()
        {
            //产生随机位置的食物
            FoodRandom();
            //显示食物
            DrawFood();
        }

    }
}
