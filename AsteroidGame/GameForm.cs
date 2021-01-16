using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();

        }
        public void Begin(int width, int heigth)
        {
            btnContinue.Left = width - btnContinue.Size.Width - (int)(btnContinue.Size.Height * 2);
            btnContinue.Top = heigth - (int)(btnContinue.Size.Height * 3.5);
            btnContinue.Hide();
            btnPause.Left = width - btnPause.Size.Width - (int)(btnPause.Size.Height * 2);
            btnPause.Top = heigth - (int)(btnPause.Size.Height * 3.5);


        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Game.Close();
            btnPause.Hide();
            btnContinue.Show();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Form main = Application.OpenForms[0];
            main.StartPosition = FormStartPosition.Manual;
            main.Left = Left;
            main.Top = Top;
            Game.Close();
            //SplashScreen.Close();
            main.Show();

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Game.Continue();
            btnContinue.Hide();
            btnPause.Show();
        }
    }
}
