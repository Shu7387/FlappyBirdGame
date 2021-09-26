using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class bird : Form
    {
        private int pipeSpeed = 8;
        private int gravity = 9;
        private int score = 0;

        public bird()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)          // Timer is like setInterval
        {
            flappyBird.Top += gravity;
            pipeDown.Left -= pipeSpeed;
            pipeUp.Left -= pipeSpeed;
            MyScore.Text = "Shubham : " + score.ToString();

            if (pipeDown.Left < -60)
            {
                pipeDown.Left = 600;
                score++;
            }
            if (pipeUp.Left < -100)
            {
                pipeUp.Left = 730;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeDown.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeUp.Bounds) ||
               flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
               )
            {
                endGame();
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -9;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 9;
            }
        }

        public void endGame()
        {
            gameTimer.Stop();

            MyScore.Text = score.ToString() + "  ~  Game is Over";

            MyScore.BackColor = Color.Red;
        }
    }
}