﻿using System;
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
        public Food() 
        {

        }


        public void DrawFood(Form Main) 
        {
            g = Main.CreateGraphics();
            

        }
    }
}
