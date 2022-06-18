using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_Planning
{
    internal class Block
    {
        //蛇身体的每一单元，简称块
      
            //是否为蛇头
            private bool _isHead;

            public bool IsHead
            {
                get { return _isHead; }
                set { _isHead = value; }
            }
            //蛇块的编号
            private int _blockNumber;

            public int BlockNumber
            {
                get { return _blockNumber; }
                set { _blockNumber = value; }
            }
            //蛇块的左上角位置
            private Point _origin;

            public Point Origin
            {
                get { return _origin; }
                set { _origin = value; }
            }

            //根据指定位置画蛇块
            public void ShowBlock(Graphics g)
            {
                Bitmap bitMap;
                if (IsHead)
                {
                    //蛇头
                    bitMap = new Bitmap(Image.FromFile("Blue.gif"));
                }
                else
                {
                    bitMap = new Bitmap(Image.FromFile("Yellow.gif"));
                }
                g.DrawImage(bitMap, Origin.X, Origin.Y, 15, 15);
            }

            //消除蛇块
            public void UnShowBlock(Graphics g)
            {
                SolidBrush brush = new SolidBrush(Color.Silver);
                g.FillRectangle(brush, Origin.X, Origin.Y, 15, 15);
            }
        }
    }

