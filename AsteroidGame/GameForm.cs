using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidGame.Objects;

namespace AsteroidGame
{
    public partial class GameForm : Form
    {
        private Timer __timer = new Timer();
        public GameForm()
        {
            InitializeComponent();
            __timer.Start();
            __timer.Tick += Game.Timer_Tick;
            KeyDown += Game.Form_KeyDown;
            Ship.MessageDie += Finish;

        }
        public void Begin(int width, int heigth)
        {
            btnContinue.Left = width - btnContinue.Size.Width - (int)(btnContinue.Size.Height * 2);
            btnContinue.Top = heigth - (int)(btnContinue.Size.Height * 3.5);
            btnContinue.Hide();
            btnPause.Left = width - btnPause.Size.Width - (int)(btnPause.Size.Height * 2);
            btnPause.Top = heigth - (int)(btnPause.Size.Height * 3.5);


        }
        public void Finish()
        {
            __timer.Stop();
            Game.__buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Game.__buffer.Render();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            __timer.Stop();
            btnContinue.Show();
            btnPause.Hide();
            
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form main = Application.OpenForms[0];
            main.StartPosition = FormStartPosition.Manual;
            main.Left = Left;
            main.Top = Top;
            __timer.Stop();
            main.Show();

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            __timer.Start();
            btnPause.Show();
            btnContinue.Hide();
            
        }
    }
}
