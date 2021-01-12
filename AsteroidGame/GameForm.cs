﻿using System;
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
            Game.Init(this);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.timer.Tick -= Game.Timer_Tick;
            Game.Buffer.Dispose();
            Form main = Application.OpenForms[0];
            main.StartPosition = FormStartPosition.Manual;
            main.Left = this.Left;
            main.Top = this.Top;
            main.Show();
        }
    }
}