
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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

        //定时器
        Timer timer;

       
        public Game()
        {
            InitializeComponent();
            init();
        }
        //键盘响应事件
        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            char w = (char)e.KeyValue;
            int d = -1;
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
            if(d  != -1)
            {
                map.snake.TurnDirection(d);
            }    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            map.snake.Go();
            map.DrawMap();
            panel1.CreateGraphics().DrawImage(bmp, 0, 0);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Play();
        }
        public void addScore()
        {
            score += 50;
            level = score / 100 + 1;
            speed = (int)(500 * (1.0 / level));
            timer.Interval = speed;
            label2.Text = score.ToString();
            label4.Text = level.ToString();
        }
        public void gameOver()
        {
            Quit quit = new Quit();
            quit.game = this;
            quit.Show();
        }

        public void Play()
        {
            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(@"open ""D:\VS2022code\Snake-Game-Planning\music\萌萌哒的徐老师 - Color-X (Remix).mp3"" alias temp_alias", null, 0, 0); //音乐文件
            mciSendString("play temp_alias repeat", null, 0, 0);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        public void init()
        {
            panel1.BackColor = Color.Gray;

            bmp = new Bitmap(627, 470);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Gray);
            
            map = new Map(g, 15, 30, 25);
            map.addScore += addScore;
            map.gameOver += gameOver;

            //分数从0开始，关卡从1开始
            score = 0;
            level = 1;
            speed = 500;
            label2.Text = score.ToString();
            label4.Text = level.ToString();
            
            map.start();
            map.DrawMap();
            g.DrawImage(bmp, 0, 0);

            //定义一个计时器
            if (timer != null)
            {
                timer.Stop();
            }
            timer = new Timer();
            timer.Interval = speed;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);

    }
}
