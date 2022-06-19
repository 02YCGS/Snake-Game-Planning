using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game_Planning
{
    public partial class Game : Form
    {
        Map map;
        static Bitmap bmp = new Bitmap(627,470);
        Graphics g = Graphics.FromImage(bmp);
        //定义分数
        int score = 0;
        //定义关卡
        int level = 1;
        public Game()
        {
            InitializeComponent();
            map = new Map(g, 15, 30, 25);
            label2.Text = score.ToString();
            label4.Text = level.ToString();
        }
        //键盘响应事件
        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            string w = e.KeyValue.ToString();
            int d;
            if(w.Equals("w"))
            {
                d = 0;
            }else if(w.Equals("d"))
            {
                d = 1;
            }else if (w.Equals("s"))
            {
                d = 2;
            }else if (w.Equals("a"))
            {
                d = 3;
            }
        }
    }
}
