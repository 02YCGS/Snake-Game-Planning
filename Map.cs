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
        public Graphics g;
        //每个方格的长度
        public int unit;
        //定义列数
        public int column;
        //定义行数
        public int row;
        //定义地图的长度
        public readonly int length;
        //定义地图的宽度
        public readonly int width;
        public Snake snake;

        public bool victory = false;

        public Food food;

        public delegate void GameOver();
        public GameOver gameOver;

        public delegate void AddScore();
        public AddScore addScore;
        public Map(Graphics g,int unit,int column,int row) 
        {
            this.g = g;
            this.unit = unit ;
            this.column = column;
            this.row = row;
            this.length = column * unit;
            this.width = row * unit;
        }

        public void start()
        {
            snake = new Snake(this);
            food = new Food(this);
            DrawMap();
            food.DrawNewFood();
        }

        public void DrawMap()
        {
            //g.DrawRectangle(new Pen(Color.Red), 0, 0, length, width);
        }

    }
}
