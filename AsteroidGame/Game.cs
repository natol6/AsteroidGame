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
            
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) __bullet = new Bullet(new Point(__ship.Rect.X + 20, __ship.Rect.Y + 20), new Point(5, 0), new Size(5, 2));
            if (e.KeyCode == Keys.I) __ship.Up();
            if (e.KeyCode == Keys.J) __ship.Down();
            /*switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    __bullet = new Bullet(new Point(__ship.Rect.X + 10, __ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
                    break;

                case Keys.Up:
                    __ship.Up();
                    System.Media.SystemSounds.Hand.Play();
                    break;

                case Keys.Down:
                    __ship.Down();
                    System.Media.SystemSounds.Asterisk.Play();
                    break;
            }*/
        }
        
        public static void Draw()
        {
            
            __buffer.Graphics.DrawImage(__background, 0, 0, Width, Height);
            foreach (BaseObject obj in __objs)
                obj.Draw();
            foreach (Asteroid ast in __asteroids)
                ast?.Draw();
            __bullet?.Draw();
            __ship?.Draw();
            if (__ship != null)
                __buffer.Graphics.DrawString("Energy:" + __ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            __buffer.Render();

        }
        public static void Update()
        {
            foreach (BaseObject obj in __objs)
                obj.Update();
            __bullet?.Update();
            for (var i = 0; i < __asteroids.Length; i++)
            {
                if (__asteroids[i] == null) continue;
                __asteroids[i].Update();
                if (__bullet != null && __bullet.Collision(__asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    __asteroids[i] = null;
                    __bullet = null;
                    continue;
                }
                if (!__ship.Collision(__asteroids[i])) continue;
                __ship?.EnergyLow(Program.rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (__ship.Energy <= 0) __ship?.Die();
            }
            
               

        }

        
        public static void Load()
        {
            int j;
            __objs = new BaseObject[150];
            __asteroids = new Asteroid[10];
            __objs[0] = new Comet(new Point(Game.Width, 100), new Point(-25, 0), new Size(100, 100));
            for (int i = 1; i < 3; i++)
                __objs[i] = new Nlo(new Point(Program.rnd.Next(10, Width - 10), Program.rnd.Next(10, Height - 10)), new Point(Program.rnd.Next(5, 15), Program.rnd.Next(5, 15)), new Size(50, 42));
            for (int i = 3; i < __objs.Length; i++)
                __objs[i] = new Star(new Point(Program.rnd.Next(0, Width), Program.rnd.Next(0, Height)), new Point(-Program.rnd.Next(1, 20), 0), new Size(i + 1, i + 1));
            __asteroids[0] = new Asteroid(new Point(Game.Width, 50), new Point(-15, 5), new Size(60, 60));
            for (int i = 1; i < __asteroids.Length / 3 + 1; i++)
            {
                j = 1;
                __asteroids[i * j] = new Asteroid(new Point(Width, Program.rnd.Next(20, Height - 20)), new Point(Program.rnd.Next(-20, - 6), Program.rnd.Next(-10, 11)), new Size(60, 60));
                j++;
                __asteroids[i * j] = new Asteroid(new Point(Program.rnd.Next(Width / 3, Width), 0), new Point(Program.rnd.Next(-20, -6), Program.rnd.Next(1, 11)), new Size(20, 20));
                j++;
                __asteroids[i * j] = new Asteroid(new Point(Program.rnd.Next(Width / 3, Width), Height), new Point(Program.rnd.Next(-20, -6), Program.rnd.Next(-11, -1)), new Size(40, 40));
            
            }
            __ship = new Ship(new Point(30, (int)(Height / 2)), new Point(5, 5), new Size(15, 15));
            __bullet = new Bullet(new Point(__ship.Rect.X + 20, __ship.Rect.Y + 20), new Point(5, 0), new Size(5, 2));
            
        }
        
    }
}