using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AsteroidGame.Objects;

namespace AsteroidGame
{
    static class SplashScreen
    {
        private static BufferedGraphicsContext __context;
        internal static BufferedGraphics __buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static readonly Image __background = Properties.Resources.main5;
        private static BaseObject[] __objs;
        private static Timer __timer = new Timer { Interval = 100 };
        static SplashScreen()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            __context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы, 
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            __buffer = __context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            __timer.Start();
            __timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Close() => __timer.Stop();
        public static void Draw()
        {
            
            __buffer.Graphics.DrawImage(__background, 0, 0, Width, Height);
            foreach (BaseObject obj in __objs)
                obj.Draw();
            if (__timer.Enabled) __buffer.Render();

        }
        public static void Update()
        {
            foreach (BaseObject obj in __objs)
                obj.Update();
        }

        public static void Load()
        {
            __objs = new BaseObject[100];
            
            for (int i = 0; i < __objs.Length; i++)
                __objs[i] = new StarMain(new Point(Program.rnd.Next(0, Width), Program.rnd.Next(0, Height)), new Point(-Program.rnd.Next(1, 20), 0), new Size(i + 1, i + 1));
            
        }
    }
}
