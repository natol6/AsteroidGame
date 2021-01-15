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
    static class Game
    {
        private static BufferedGraphicsContext __context;
        internal static BufferedGraphics __buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Random __random { get; } = new Random();
        private static readonly Image __background = Properties.Resources.fon1; //Image.FromFile("fon.jpg");
        private static BaseObject[] __objs;
        private static Timer __timer = new Timer { Interval = 100 };
        static Game()
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
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            __buffer = __context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            __timer.Start();
            __timer.Tick += Timer_Tick;
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Close() => __timer.Stop();
        public static void Draw()
        {
            
            __buffer.Graphics.DrawImage(__background, 0, 0);
            foreach (BaseObject obj in __objs)
                obj.Draw();
            if(__timer.Enabled) __buffer.Render();
            

        }
        public static void Update()
        {
            foreach (BaseObject obj in __objs)
                obj.Update();
        }

        
        public static void Load()
        {
            __objs = new BaseObject[100];
            __objs[0] = new Comet(new Point(Game.Width, 100), new Point(-25, 0), new Size(100, 100));
            for (int i = 1; i < 3; i++)
                __objs[i] = new Nlo(new Point(__random.Next(10, Width - 10), __random.Next(10, Height - 10)), new Point(__random.Next(5, 15), __random.Next(5, 15)), new Size(50, 42));
            for (int i = 3; i < __objs.Length - 4; i++)
                __objs[i] = new Star(new Point(__random.Next(0, Width), __random.Next(0, Height)), new Point(-__random.Next(1, 20), 0), new Size(i + 1, i + 1));
            __objs[^4] = new Asteroid(new Point(Game.Width, 50), new Point(-15, 5), new Size(60, 60));
            __objs[^3] = new Asteroid(new Point(1000, 0), new Point(-20, 8), new Size(20, 20));
            __objs[^2] = new Asteroid(new Point(800, Game.Height), new Point(-15, -2), new Size(40, 40));
            __objs[^1] = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
        }
    }
}
