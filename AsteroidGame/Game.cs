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
        private static readonly Image __background = Properties.Resources.fon1;
        private static BaseObject[] __objs;
        private static Asteroid[] __asteroids;
        private static Bullet __bullet;
        private static Ship __ship;
        //private static Timer __timer = new Timer { Interval = 100 };
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
            //Program.__timer.Start();
            //Program.__timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) __bullet = new Bullet(new Point(__ship.Rect.X + 10, __ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) __ship.Up();
            if (e.KeyCode == Keys.Down) __ship.Down();
        }
        //public static void Close() => Program.__timer.Stop();
        //public static void Continue() => Program.__timer.Start();
        public static void Draw()
        {
            
            __buffer.Graphics.DrawImage(__background, 0, 0, Width, Height);
            foreach (BaseObject obj in __objs)
                obj.Draw();
            foreach (Asteroid ast in __asteroids)
                ast.Draw();
            __bullet.Draw();
            //if(GameForm.__timer.Enabled) __buffer.Render();
            __buffer.Render();

        }
        public static void Update()
        {
            foreach (BaseObject obj in __objs)
                obj.Update();
            foreach (Asteroid ast in __asteroids)
            {
                ast.Update();
                if (ast.Collision(__bullet)) 
                { 
                    System.Media.SystemSounds.Hand.Play();
                    __bullet.GenerateNew();
                    ast.GenerateNew();

                }
            }
            __bullet.Update();   

        }

        
        public static void Load()
        {
            __objs = new BaseObject[150];
            __asteroids = new Asteroid[3];
            __objs[0] = new Comet(new Point(Game.Width, 100), new Point(-25, 0), new Size(100, 100));
            for (int i = 0; i < 2; i++)
                __objs[i] = new Nlo(new Point(Program.rnd.Next(10, Width - 10), Program.rnd.Next(10, Height - 10)), new Point(Program.rnd.Next(5, 15), Program.rnd.Next(5, 15)), new Size(50, 42));
            for (int i = 2; i < __objs.Length; i++)
                __objs[i] = new Star(new Point(Program.rnd.Next(0, Width), Program.rnd.Next(0, Height)), new Point(-Program.rnd.Next(1, 20), 0), new Size(i + 1, i + 1));
            __asteroids[0] = new Asteroid(new Point(Game.Width, 50), new Point(-15, 5), new Size(60, 60));
            __asteroids[1] = new Asteroid(new Point(1000, 0), new Point(-20, 8), new Size(20, 20));
            __asteroids[2] = new Asteroid(new Point(800, Game.Height), new Point(-15, -2), new Size(40, 40));
            __bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            __ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        }
    }
}
