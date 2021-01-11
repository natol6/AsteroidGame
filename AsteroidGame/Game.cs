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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Random Random { get; } = new Random();
        static Image background = Image.FromFile("Images\\fon.jpg");
        static Game()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.DrawImage(background, 0, 0);
            //Buffer.Render();
            //Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();

        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static BaseObject[] _objs;
        public static void Load()
        {
            _objs = new BaseObject[100];
            _objs[0] = new Comet(new Point(Game.Width, 100), new Point(-25, 0), new Size(100, 100));
            for (int i = 1; i < 3; i++)
                _objs[i] = new Nlo(new Point(Random.Next(10, Width - 10), Random.Next(10, Height - 10)), new Point(Random.Next(5, 15), Random.Next(5, 15)), new Size(50, 42));
            for (int i = 3; i < _objs.Length - 3; i++)
                _objs[i] = new Star(new Point(Random.Next(0, Width), Random.Next(0, Height)), new Point(-Random.Next(1, 20), 0), new Size(i + 1, i + 1));
            _objs[_objs.Length - 3] = new Asteroid(new Point(Game.Width, 50), new Point(-15, 5), new Size(60, 60));
            _objs[_objs.Length - 2] = new Asteroid(new Point(1000, 0), new Point(-20, 8), new Size(20, 20));
            _objs[_objs.Length - 1] = new Asteroid(new Point(800, Game.Height), new Point(-15, -2), new Size(40, 40));
        }
    }
}
