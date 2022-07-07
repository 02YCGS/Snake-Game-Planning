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
    public partial class Main : Form { 
        public Main()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"D:\VS2022code\Snake-Game-Planning\Image\img1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
