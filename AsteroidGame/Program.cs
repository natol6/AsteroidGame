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
        public static Random rnd = new Random(); 
        //  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main = new MainForm();
            main.Width = Screen.PrimaryScreen.Bounds.Width;
            main.Height = Screen.PrimaryScreen.Bounds.Height;
            Application.Run(main);
            
        }
    }
}
