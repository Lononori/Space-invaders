using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_invaders
{
    public partial class Form1 : Form
    {
        bool goleft;
        bool goright;
        int speed = 5;
        int score = 0;
        bool isPressed;
        int totalEnemys = 12;
        int playerSpeed = 6;        
        public Form1()
        {
            InitializeComponent();
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                makeBullet();
            }

           
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft)
            {
                Player.Left -= playerSpeed;
            }
            else if (goright)
            {
                Player.Left += playerSpeed;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "Invaders")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(Player.Bounds))
                    {
                        gameover();
                    }
                    if(((PictureBox)x).Left + speed <Width)
                    {
                        ((PictureBox)x).Left += speed;
                    }
                      
                    if (((PictureBox)x).Left > 720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                        ((PictureBox)x).Left = -50;
                    }
                    

                }
            }

        }
        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "bullet";
            bullet.Left = Player.Left + Player.Width / 2;
            bullet.Top = Player.Top - 20;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
        private void gameover()
        {
            timer1.Stop();
            label1.Text += "Game Over";
        }
    }
}
