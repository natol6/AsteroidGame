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
    public partial class MainForm : Form
    {
        Player player;
        Records records;
        
        public MainForm()
        {
            InitializeComponent();
            lblGameName.Left = ClientSize.Width / 2 - lblGameName.Size.Width / 2;
            lblNik.Left = ClientSize.Width / 2 - lblNik.Size.Width / 2;
            btnGame.Hide();
            btnRecords.Hide();
            btnExit.Hide();
            label1.Hide();
            player = new Player();
            records = new Records();
            records.Load();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string nikName = textBoxNik.Text;
            if (nikName.Length > 20)
            {
                textBoxNik.Text = "";
                MessageBox.Show("Длина введенного имени (ника) игрока превышает максимально возможную. Имя (ник) игрока не должно превышать 20 символов. Повторите ввод. ", "Сообщение:");
            }
            else
            {
                player.Nik = textBoxNik.Text;
                textBoxNik.Hide();
                btnOk.Hide();
                lblNik.Hide();
                label1.Show();
                btnGame.Show();
                btnRecords.Show();
                btnExit.Show();
                SplashScreen.Init(this);
            }
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            GameForm game = new GameForm();
            game.Height = Height;
            game.Width = Width;
            game.Left = Left;
            game.Top = Top;
            Game.Init(game);
            game.Show();
            Hide();
            
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            MessageBox.Show(records.ToString(player), "Таблица рекордов:");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
