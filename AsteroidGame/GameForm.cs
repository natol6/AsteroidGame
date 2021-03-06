﻿using System;
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
        private Timer __timerLevel = new Timer();
        private int __record = 0;
        public GameForm()
        {
            InitializeComponent();
            
        }
        public void BeginForm(int width, int heigth)
        {
            btnContinue.Left = width - btnContinue.Size.Width - (int)(btnContinue.Size.Height * 2);
            btnContinue.Top = heigth - (int)(btnContinue.Size.Height * 3.5);
            btnContinue.Hide();
            btnPause.Left = width - btnPause.Size.Width - (int)(btnPause.Size.Height * 2);
            btnPause.Top = heigth - (int)(btnPause.Size.Height * 3.5);
            Font font = new Font("Tahoma", width / 90, FontStyle.Bold);
            lblRecName.Font = font;
            lblRecName.Left = (int)(lblRecName.Size.Height * 2);
            lblRecName.Top = heigth - (int)(lblRecName.Size.Height * 4.5);
            lblRecValue.Font = font;
            lblRecValue.Left = lblRecName.Left + lblRecName.Size.Width + 10;
            lblRecValue.Top = lblRecName.Top;
            lblEnergyName.Font = font;
            lblEnergyName.Left = lblRecValue.Left + lblRecValue.Size.Width + 30;
            lblEnergyName.Top = lblRecName.Top;
            lblEnergyValue.Font = font;
            lblEnergyValue.Left = lblEnergyName.Left + lblEnergyName.Size.Width + 10;
            lblEnergyValue.Top = lblRecName.Top;
        }
        public void BeginGame()
        {
            
            __timer.Interval = 100;
            __timerLevel.Interval = 3000;
            __timer.Tick += Game.Timer_Tick;
            __timerLevel.Tick += GameOpen;
            KeyPreview = true;
            KeyDown += Game.Form_KeyDown;
            Ship.MessageDie += Finish;
            Ship.MessageEn += EnergyRob;
            Ship.MessageEnPlus += EnergyPlus;
            Bullet.MessageBullet += RecordPlus;
            Asteroid.AsteroidDel += AstNew;
            Game.Draw();
            Game.DrawBegin();
            __timerLevel.Start();
        }
        public void Finish()
        {
            __timer.Stop();
            Game.__buffer.Graphics.DrawString("Ваш корабль разрушен!\n\nИгра окончена.", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.OrangeRed, 200, 100);
            Game.__buffer.Render();
        }
        
        public void RecordPlus() 
        { 
            __record++;
            lblRecValue.Text = "" +__record;
        }
        public void EnergyRob()
        {
            int en = Game.EnergyShip();
            lblEnergyValue.Text = "" + en;
            if (en < 20)
            {
                lblEnergyName.ForeColor = Color.Red;
                lblEnergyValue.ForeColor = Color.Red;
            }
            else if(en < 60)
            {
                lblEnergyName.ForeColor = Color.Yellow;
                lblEnergyValue.ForeColor = Color.Yellow;
            }
        }
        public void EnergyPlus()
        {
            int en = Game.EnergyShip();
            lblEnergyValue.Text = "" + en;
            if (en > 60)
            {
                lblEnergyName.ForeColor = Color.Lime;
                lblEnergyValue.ForeColor = Color.Lime;
            }
            else if (en < 20)
            {
                lblEnergyName.ForeColor = Color.Yellow;
                lblEnergyValue.ForeColor = Color.Yellow;
            }
        }
        public void AstNew()
        {
            if (Game.AstDel())
            {
                __timer.Stop();
                Game.AstUpdate();
                Game.DrawBegin();
                __timerLevel.Start();
                
            }
        }
        public void GameOpen(object sender, EventArgs e)
        {
            __timerLevel.Stop();
            __timer.Start();
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

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
