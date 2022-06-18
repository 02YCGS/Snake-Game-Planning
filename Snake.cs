using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_Planning
{
    internal class Snake
    {
       
            //用于存放蛇的集合
            private List<Block> blocksList;
            //0-上，1-右，2-下，3-左
            private int direction = 1;
            //蛇头的编号，蛇的长度
            private int headNumber;
            //蛇头左上角坐标
            private Point headPoint;
            private Point mapLeft;
            //游戏开始时，初始的蛇
            public Snake(Point map, int count)
            {
                mapLeft = map;
                Block blockSnake;
                //定义蛇的起始位置（蛇尾）
                Point p = new Point(map.X + 15, map.Y + 15);
                blocksList = new List<Block>();
                //循环画蛇块用于填充蛇集合
                for (int i = 0; i < count; i++)
                {
                    //x坐标加15
                    p.X += 15;
                    //实例化蛇块
                    blockSnake = new Block();
                    //定义蛇块的左上角位置
                    blockSnake.Origin = p;
                    //定义蛇块的编号1，2，3...
                    blockSnake.BlockNumber = i + 1;
                    if (i == count - 1)
                    {
                        //蛇头
                        //给蛇头位置赋值
                        headPoint = blockSnake.Origin;
                        blockSnake.IsHead = true;
                    }
                    blocksList.Add(blockSnake);

                }
                //蛇的长度赋值
                headNumber = count;
            }
            //蛇头坐标的只读属性
            public Point HeadPoint
            {
                get { return headPoint; }
            }
            //蛇的运动方向的属性
            public int Direction
            {
                get { return direction; }
                set { direction = value; }
            }
            /// <summary>
            /// 蛇的转换方向
            /// </summary>
            /// <param name="pDirection">想要改变的方向</param>
            public void TurnDirection(int pDirection)
            {
                switch (direction)
                {
                    //原来向上运动
                    case 0:
                        //希望向左运动
                        if (pDirection == 3)
                            direction = 3;
                        //希望向右运动
                        else if (pDirection == 1)
                            direction = 1;
                        break;
                    //原来向右运动
                    case 1:
                        //下
                        if (pDirection == 2)
                            direction = 2;
                        //上
                        else if (pDirection == 0)
                            direction = 0;
                        break;
                    case 2:
                        if (pDirection == 1)
                            direction = 1;
                        else if (pDirection == 3)
                            direction = 3;
                        break;
                    case 3:
                        if (pDirection == 0)
                            direction = 0;
                        else if (pDirection == 2)
                            direction = 2;
                        break;


                }
            }

            public Point getHeadPoint //只读蛇头位置属性
            {
                get { return headPoint; }
            }
            //蛇吃到食物后变长，蛇头+1
            public void SnakeGrowth()
            {
                //找到蛇头的坐标
                Point head = blocksList[blocksList.Count - 1].Origin;
                int x = head.X;
                int y = head.Y;
                //判断蛇的运动方向,改变蛇头的位置
                switch (direction)
                {
                    case 0:
                        //向上运动
                        y -= 15;
                        break;
                    case 1:
                        x += 15;
                        break;
                    case 2:
                        y += 15;
                        break;
                    case 3:
                        x -= 15;
                        break;
                }
                //把原先蛇头的块变为普通块
                blocksList[blocksList.Count - 1].IsHead = false;
                //实例化新蛇头
                Block headNew = new Block();
                headNew.IsHead = true;
                headNew.BlockNumber = blocksList.Count + 1;
                headNew.Origin = new Point(x, y);
                blocksList.Add(headNew);
                headNumber++;
                headPoint = headNew.Origin;
            }

            //蛇向前运动（没有吃到食物的情况），蛇尾移除，蛇头移位+1
            public void Go(Graphics g)
            {
                Block snakeTail = blocksList[0];
                //消除蛇尾块
                snakeTail.UnShowBlock(g);
                //集合中移除设为块
                blocksList.RemoveAt(0);
                foreach (var item in blocksList)
                {
                    item.BlockNumber--;
                }
                //由于SnakeGrowth中仅仅使蛇头+1，但是headNumber++了。但是此值并没有改变，所以先--
                headNumber--;
                SnakeGrowth();
            }

            //画出蛇
            public void ShowSnake(Graphics g)
            {
                foreach (var item in blocksList)
                {
                    item.ShowBlock(g);
                }
            }
            //隐藏蛇
            public void UnShowSnake(Graphics g)
            {
                foreach (var item in blocksList)
                {
                    item.UnShowBlock(g);
                }
            }
            //重置蛇
            public void Reset(Point map, int count)
            {
                Block blockSnake;
                //定义蛇的起始位置（蛇尾）
                Point p = new Point(mapLeft.X + 15, mapLeft.Y + 15);
                blocksList = new List<Block>();
                //循环画蛇块用于填充蛇集合
                for (int i = 0; i < count; i++)
                {
                    //x坐标加15
                    p.X += 15;
                    //实例化蛇块
                    blockSnake = new Block();
                    //定义蛇块的左上角位置
                    blockSnake.Origin = p;
                    //定义蛇块的编号1，2，3...
                    blockSnake.BlockNumber = i + 1;
                    if (i == count - 1)
                    {
                        //蛇头
                        //给蛇头位置赋值
                        headPoint = blockSnake.Origin;
                        blockSnake.IsHead = true;
                    }
                    blocksList.Add(blockSnake);

                }
                //蛇的长度赋值
                headNumber = count;
                direction = 1;
            }
            //是否碰到自己
            public bool IsTouchMyself()
            {
                bool isTouched = false;
                for (int i = 0; i < blocksList.Count - 1; i++)
                {
                    if (headPoint == blocksList[i].Origin)
                    {
                        isTouched = true;
                        break;
                    }
                }
                return isTouched;
            }
        }
}
