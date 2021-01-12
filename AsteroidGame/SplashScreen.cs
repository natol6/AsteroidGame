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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Random Random { get; } = new Random();
        static Image background = Image.FromFile("Images\\main55.jpg");
        static BaseObject[] _objs;
        static SplashScreen()
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
            
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();

        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        //public static BaseObject[] _objs;
        public static void Load()
        {
            _objs = new BaseObject[100];
            
            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new StarMain(new Point(Random.Next(0, Width), Random.Next(0, Height)), new Point(-Random.Next(1, 20), 0), new Size(i + 1, i + 1));
            
        }
    }
}
