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
        static Program()
        {
        }
        
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main = new MainForm();
            __width = 1200; // Ширину экрана можно задавать при запуске программы
            __height = __width * 9 / 16;
            if (__width < 800 || __width > Screen.PrimaryScreen.Bounds.Width || __height < 450 || __height > Screen.PrimaryScreen.Bounds.Height)
                throw new ArgumentOutOfRangeException("Main Form", "Задана некорректная ширина окна при инициализации главной формы. Ширина должна быть в пределах от 800 пикс. до ширины экрана монитора.");
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
