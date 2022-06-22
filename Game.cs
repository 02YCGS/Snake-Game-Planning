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
        Bitmap bmp;
        Graphics g;
        //定义分数
        int score = 0;
        //定义关卡
        int level = 1;
        //定义速度
        int speed = 500;
        public Game()
        {
            InitializeComponent();
            bmp = new Bitmap(627, 470);
            g = Graphics.FromImage(bmp);

            map = new Map(g, 15, 30, 25);
            map.addScore += addScore;
            map.gameOver += gameOver;

            panel1.BackColor = Color.Gray;
            label2.Text = score.ToString();
            label4.Text = level.ToString();
        }


                 //键盘响应事件
        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            char w = (char)e.KeyValue;
            int d = 1;
            if(w.Equals('W'))
            {
                d = 0;
            }else if(w.Equals('D'))
            {
                d = 1;
            }else if (w.Equals('S'))
            {
                d = 2;
            }else if (w.Equals('A'))
            {
                d = 3;
            }
            map.snake.TurnDirection(d);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = speed;
            map.snake.Go();
            panel1.CreateGraphics().DrawImage(bmp, 0, 0);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            map.start();
        }


          public void addScore()
        {
            score += 10;
            level = score / 100 + 1;
            speed = (int)(500 * (1.0 / level));
            label2.Text = score.ToString();
            label4.Text = level.ToString();
        }
        public void gameOver()
        {
            Quit quit = new Quit();
            quit.game = this;
            quit.Show();
            quit.Owner = this.Owner;
        }

    }
}
