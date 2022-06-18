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

        public Food(Graphics g) 
        {
            this.g = g;
        }
        /// <summary>
        /// 绘画食物
        /// </summary>
        /// <param name="g"></param>
        public void DrawFood(Graphics g) 
        {
            g.FillEllipse(new SolidBrush(Color.Red), Location.X, Location.Y, 15, 15);
        }
        /// <summary>
        /// 清除食物
        /// </summary>
        public void DeleteFood()
        {
            g.FillEllipse(new SolidBrush(Color.White), Location.X, Location.Y, 15, 15);
        }
    }
}
