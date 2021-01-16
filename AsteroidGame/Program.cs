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
        private static int __width;
        private static int __height;
        
        //  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main = new MainForm();
            __width = 800;
            __height = 500;
            if (__width < 800 || __width > Screen.PrimaryScreen.Bounds.Width || __height < 500 || __height > Screen.PrimaryScreen.Bounds.Height)
                throw new ArgumentOutOfRangeException("Main Form", "«аданы некорректные размеры окна при инициализации главной формы.");
            else
            {
                main.Width = __width;
                main.Height = __height;
                main.Begin(main.Width, main.Height);
                Application.Run(main);
            }
            
            
            
           
        }
    }
}
