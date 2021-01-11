using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Comet: BaseObject
    {
        Image[] images = {
            Image.FromFile("Images\\comets\\comet-0.png"),
            Image.FromFile("Images\\comets\\comet-60.png"),
            Image.FromFile("Images\\comets\\comet-30.png"),
            Image.FromFile("Images\\comets\\comet--30.png"),
            Image.FromFile("Images\\comets\\comet--60.png")};
        int i = 0;
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(images[i], Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < -Size.Width || Pos.Y < -Size.Height || Pos.Y > Game.Height + Size.Height)
            {
                Random rnd = new Random();
                Size.Width = rnd.Next(70, 121);
                Size.Height = Size.Width;
                switch (rnd.Next(1, 5))
                {
                    case 1: //-60
                        if (rnd.Next(1, 3) == 1)
                        {
                            Pos.X = rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = 0 - Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = rnd.Next(0, Game.Height / 3);
                        }
                        i = 4;
                        Dir.X = -10;
                        Dir.Y = 18;
                        break;
                    case 2: //-30
                        if (rnd.Next(1, 3) == 1)
                        {
                            Pos.X = rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = 0 - Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = rnd.Next(0, Game.Height / 3);
                        }
                        i = 3;
                        Dir.X = -18;
                        Dir.Y = 10;
                        break;
                    case 3: //30
                        if (rnd.Next(1, 3) == 1)
                        {
                            Pos.X = rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = Game.Height + Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = rnd.Next(Game.Height * 2 / 3, Game.Height);
                        }
                        i = 2;
                        Dir.X = -18;
                        Dir.Y = -10;
                        break;
                    case 4: //60
                        if (rnd.Next(1, 3) == 1)
                        {
                            Pos.X = rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = Game.Height + Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = rnd.Next(Game.Height * 2 / 3, Game.Height);
                        }
                        i = 1;
                        Dir.X = -10;
                        Dir.Y = -18;
                        break;
                    default:
                        Pos.X = Game.Width + Size.Width;
                        Pos.Y = rnd.Next(120, Game.Height - 120);
                        i = 0;
                        Dir.X = -22;
                        Dir.Y = 0;
                        break;


                }
            }

        }
    }
}
