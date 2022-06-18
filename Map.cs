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
        /// <summary>
        /// 每个蛇块的长度
        /// </summary>
        public static int unit = 15;
        /// <summary>
        /// 定义地图的长度
        /// </summary>
        public readonly int length = 30 * unit;
        /// <summary>
        /// 定义地图的宽度
        /// </summary>
        public readonly int widht = 25 * unit;
        /// <summary>
        /// 定义初始分数
        /// </summary>
        public int score = 0;

        public Map(Point start) 
        {

        }

    }
}
