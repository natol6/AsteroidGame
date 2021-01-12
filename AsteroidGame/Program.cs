using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main = new MainForm();
            //GameForm main = new GameForm();
            Application.Run(main);
            //Form form = new Form();
            //form.Width = 800;
            //form.Height = 600;
            //Game.Init(form);
            //SplashScreen.Init(form);
            //form.Show();
            //Game.Draw();
            //Application.Run(form);
        }
    }
}
