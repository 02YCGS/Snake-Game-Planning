using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game_Planning
{
    internal class Snake
    {
        Graphics g;
        Map map;
        //用于存放蛇身体的坐标的集合
        private List<Point> bodyList;
        //0-上，1-右，2-下，3-左
        private int direction = 1;
        private int old_direction = 1;
        public bool status = true;
        
        //游戏开始时，初始的蛇
        public Snake(Map map)            
        {
            this.g = map.g;
            this.map = map;
            bodyList = new List<Point>();
            //定义尾部坐标
            headInsert(new Point(0, 0));
            //定义头部坐标
            headInsert(new Point(1,0));

        }
        /// <summary>
        /// 蛇的转换方向
        /// 不能往反方向走
        /// </summary>
        /// <param name="pDirection">想要改变的方向</param>
        public void TurnDirection(int pDirection)
        {
            //0-上，1-右，2-下，3-左
            switch (pDirection)
            {
                case 0:
                    if(old_direction != 2)
                    {
                        direction = pDirection;
                    }
                    break;
                case 1:
                    if(old_direction != 3)
                    {
                        direction = pDirection;
                    }
                    break;
                case 2:
                    if (old_direction != 0)
                    {
                        direction = pDirection;
                    }
                    break;
                case 3:
                    if (old_direction != 1)
                    {
                        direction = pDirection;
                    }
                    break;
            }
                
        }
        /// <summary>
        /// 在列表头部插入并画出蛇头
        /// </summary>
        /// <param name="point">坐标</param>
        private void headInsert(Point point)
        {
            if (bodyList.Count != 0)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), bodyList.First().X * map.unit, bodyList.First().Y * map.unit, map.unit, map.unit);
            }
            bodyList.Insert(0, point);
            g.FillRectangle(new SolidBrush(Color.Yellow), point.X * map.unit, point.Y * map.unit, map.unit, map.unit);
        }
        //蛇吃到食物后变长，蛇头+1
        public void SnakeGrowth()
        {
            headInsert(map.food.Location);
        }

        //蛇向前运动（没有吃到食物的情况），蛇尾移除，蛇头移位+1
        public void Go()
        {
            if (!status)
            {
                return;
            }
            Point next;
            
            Point head = bodyList.First();
            switch (direction) 
            {
                case 0:
                    next = new Point(head.X, head.Y - 1);
                    break;
                case 1:
                    next = new Point(head.X + 1, head.Y);
                    break;
                case 2:
                    next = new Point(head.X, head.Y + 1);
                    break;
                case 3:
                    next = new Point(head.X - 1, head.Y);
                    break;
                default:
                    next = new Point(-1,-1);
                    break;
            }

            if (CheckSnake(next) || IsTouchMyself(next))
            {
                status = false;
                map.gameOver();
            }
            else
            {
                old_direction = direction;
                //把原来的头部变成身体的颜色
                //g.FillRectangle(new SolidBrush(Color.Blue), bodyList.First().X * map.unit, bodyList.First().Y * map.unit, map.unit, map.unit);
                if (CheckFood(next))
                {
                    map.addScore();
                    headInsert(map.food.Location);               
                    map.food.DrawNewFood();
                }
                else
                {

                    Point tail = bodyList.Last();
                    g.FillRectangle(new SolidBrush(Color.Gray), tail.X * map.unit, tail.Y * map.unit, map.unit, map.unit);        
                    headInsert(next);
                    bodyList.RemoveAt(bodyList.Count - 1);
                }
                status = true;
            }
        }
       /// <summary>
       /// 判断是否碰到自身
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public bool IsTouchMyself(Point p)
        {
            bool isTouched = false;
            for (int i = 0; i < bodyList.Count - 1; i++)
            {
                if (p .Equals(bodyList[i]))
                {
                    isTouched = true;
                    break;
                }
            }
            return isTouched;
        }
        /// <summary>
        /// 判断是否吃到了食物
        /// </summary>
        /// <returns></returns>
        public bool CheckFood(Point point)
        {
            return map.food.Location.Equals(point);
        }
        /// <summary>
        /// 判断蛇是否碰到墙壁
        /// </summary>
        /// <returns></returns>
        public bool CheckSnake(Point point)
        {
            return (point.X < 0 || point.X > map.column) || (point.Y < 0 || point.Y > map.row);
        }
        /// <summary>
        /// 判断生成的食物是否和蛇重叠
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool CheckRandom(Point point)
        {
            bool status = false;
            foreach(Point point1 in bodyList){
                if (point1.Equals(point))
                {
                    status = true;
                    break;
                }
            }
            return status;
        }
    }
}
