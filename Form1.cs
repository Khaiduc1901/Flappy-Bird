using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;
        SoundPlayer soundPlayer = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            scoreText.Text ="Score: " + score.ToString();
            if (pipeTop.Left < -50)
            {
                pipeTop.Left = 900;
                score++;
                soundPlayer.SoundLocation = @"D:\flappy-bird-resources\sfx_point.wav";
                soundPlayer.Play();
            }
            if(pipeBottom.Left < -10)
            {
                pipeBottom.Left = 800;
                score++;
                soundPlayer.SoundLocation = @"D:\flappy-bird-resources\sfx_point.wav";
                soundPlayer.Play();
            }
            if(bird.Bounds.IntersectsWith(pipeBottom.Bounds)|| 
                bird.Bounds.IntersectsWith(pipeTop.Bounds)||
                bird.Bounds.IntersectsWith(ground.Bounds) )
            {
                 endGame();
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Game Over!!!";
            soundPlayer.SoundLocation = @"D:\flappy-bird-resources\sfx_hit.wav";
            soundPlayer.Play();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
            soundPlayer.SoundLocation = @"D:\flappy-bird-resources\sfx_wing.wav ";
            soundPlayer.Play();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
            soundPlayer.SoundLocation = @"D:\flappy-bird-resources\sfx_swooshing.wav ";
            soundPlayer.Play();
        }
    }
}
