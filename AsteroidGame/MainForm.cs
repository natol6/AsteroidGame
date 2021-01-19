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
            player = new Player();
            records = new Records();
            records.Load();
        }
        public void Begin(int width, int heigth)
        {
            Font font = new Font("Tahoma", width / 28, FontStyle.Bold);
            lblGameName.Font = font;
            lblGameName.Left = width / 2 - lblGameName.Size.Width / 2;
            lblGameName.Top = lblGameName.Size.Height;
            font = new Font("Tahoma", width / 80, FontStyle.Bold);
            lblNik.Font = font; 
            lblNik2.Font = font;
            btnOk.Left = width - btnOk.Size.Width - (int)(btnOk.Size.Height * 2);
            btnOk.Top = heigth - (int)(btnOk.Size.Height * 3.5);
            textBoxNik.Left = btnOk.Left - textBoxNik.Size.Width - (int)(btnOk.Size.Height);
            textBoxNik.Top = btnOk.Top;
            lblNik.Left = textBoxNik.Left + (int)((btnOk.Left + btnOk.Size.Width - textBoxNik.Left) / 2) - lblNik.Size.Width / 2;
            lblNik.Top = heigth - btnOk.Size.Height * 6;
            lblNik2.Left = textBoxNik.Left + (int)((btnOk.Left + btnOk.Size.Width - textBoxNik.Left) / 2) - lblNik2.Size.Width / 2;
            lblNik2.Top = heigth - btnOk.Size.Height * 5;
            btnExit.Left = width - btnExit.Size.Width - (int)(btnExit.Size.Height * 1.5);
            btnExit.Top = heigth - (int)(btnExit.Size.Height * 2.8);
            btnRecords.Left = btnExit.Left;
            btnRecords.Top = btnExit.Top - (int)(btnExit.Size.Height * heigth / 330);
            btnGame.Left = btnExit.Left;
            btnGame.Top = btnRecords.Top - (int)(btnExit.Size.Height * heigth / 330);
            font = new Font("Tahoma", width / 45, FontStyle.Bold);
            label1.Font = font;
            label1.Left = btnGame.Left + btnGame.Size.Width - label1.Size.Width;
            label1.Top = btnGame.Top - (int)(btnExit.Size.Height * heigth / 330);
            font = new Font("Tahoma", width / 110, FontStyle.Bold);
            lbldeveloper.Font = font;
            lbldeveloper.Left = (int)(lbldeveloper.Size.Height * 2);
            lbldeveloper.Top = heigth - (int)(lbldeveloper.Size.Height * 4.5);
            btnGame.Hide();
            btnRecords.Hide();
            btnExit.Hide();
            label1.Hide();
            
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
                lblNik2.Hide();
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
            game.Begin(game.Width, game.Height);
            Game.Init(game);
            game.Focus();
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
