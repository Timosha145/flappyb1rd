using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyb1rd
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimeEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeDown.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score:" + score;

            if (pipeDown.Left < -180)
            {
                pipeDown.Left = 800;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 800;
            }

            if (bird.Bounds.IntersectsWith(pipeDown.Bounds) || bird.Bounds.IntersectsWith(pipeTop.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Gmae Over!!!!!!!!!!!!!";
        }
    }
}
