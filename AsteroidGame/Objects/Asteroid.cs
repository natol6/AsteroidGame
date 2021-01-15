using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Asteroid: BaseObject
    {
        /*private readonly Image[] images = {
            Image.FromFile("Images\\asteroids\\asteroid-0.png"),
            Image.FromFile("Images\\asteroids\\asteroid-45.png"),
            Image.FromFile("Images\\asteroids\\asteroid-90.png"),
            Image.FromFile("Images\\asteroids\\asteroid-135.png"),
            Image.FromFile("Images\\asteroids\\asteroid-180.png"),
            Image.FromFile("Images\\asteroids\\asteroid-225.png"),
            Image.FromFile("Images\\asteroids\\asteroid-270.png"),
            Image.FromFile("Images\\asteroids\\asteroid-315.png")};*/
        private static readonly Image[] images = {
            Properties.Resources.asteroid_0,
            Properties.Resources.asteroid_45,
            Properties.Resources.asteroid_90,
            Properties.Resources.asteroid_135,
            Properties.Resources.asteroid_180,
            Properties.Resources.asteroid_225,
            Properties.Resources.asteroid_270,
            Properties.Resources.asteroid_315};
        private int i = 0;
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(images[i], Pos.X, Pos.Y, Size.Width, Size.Height);
            i++;
            if (i == 8) i -= 8;
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < -Size.Width || Pos.Y < -Size.Height || Pos.Y > Game.Height + Size.Height)
            {
                Random rnd = new Random();
                Size.Width = rnd.Next(20, 61);
                Size.Height = Size.Width;
                if (rnd.Next(1, 4) == 1)
                {
                    Pos.X = Game.Width + Size.Width;
                    Pos.Y = rnd.Next(0, Game.Height + 1);
                    Dir.Y = rnd.Next(-6, 6);
                    Dir.X = rnd.Next(-25, -8);
                }
                else
                {
                    Pos.X = rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                    if (rnd.Next(1, 3) == 1)
                    {
                        Pos.Y = Game.Height + Size.Height;
                        Dir.Y = rnd.Next(-30, -1);
                    }
                    else
                    {
                        Pos.Y = 0 - Size.Height;
                        Dir.Y = rnd.Next(1, 30);
                    }
                    Dir.X = rnd.Next(-25, -8);
                }
            }

        }
    }
}
