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
        private static readonly Image[] images = {
            Properties.Resources.comet_0,
            Properties.Resources.comet_60,
            Properties.Resources.comet_30,
            Properties.Resources.comet__30,
            Properties.Resources.comet__60};
        private int i = 0;
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(images[i], Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < -Size.Width || Pos.Y < -Size.Height || Pos.Y > Game.Height + Size.Height)
            {
                Size.Width = Program.rnd.Next(70, 121);
                Size.Height = Size.Width;
                switch (Program.rnd.Next(1, 5))
                {
                    case 1: //-60
                        if (Program.rnd.Next(1, 3) == 1)
                        {
                            Pos.X = Program.rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = 0 - Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = Program.rnd.Next(0, Game.Height / 3);
                        }
                        i = 4;
                        Dir.X = -10;
                        Dir.Y = 18;
                        break;
                    case 2: //-30
                        if (Program.rnd.Next(1, 3) == 1)
                        {
                            Pos.X = Program.rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = 0 - Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = Program.rnd.Next(0, Game.Height / 3);
                        }
                        i = 3;
                        Dir.X = -18;
                        Dir.Y = 10;
                        break;
                    case 3: //30
                        if (Program.rnd.Next(1, 3) == 1)
                        {
                            Pos.X = Program.rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = Game.Height + Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = Program.rnd.Next(Game.Height * 2 / 3, Game.Height);
                        }
                        i = 2;
                        Dir.X = -18;
                        Dir.Y = -10;
                        break;
                    case 4: //60
                        if (Program.rnd.Next(1, 3) == 1)
                        {
                            Pos.X = Program.rnd.Next(Game.Width / 2, Game.Width) + Size.Width;
                            Pos.Y = Game.Height + Size.Height;
                        }
                        else
                        {
                            Pos.X = Game.Width + Size.Width;
                            Pos.Y = Program.rnd.Next(Game.Height * 2 / 3, Game.Height);
                        }
                        i = 1;
                        Dir.X = -10;
                        Dir.Y = -18;
                        break;
                    default:
                        Pos.X = Game.Width + Size.Width;
                        Pos.Y = Program.rnd.Next(120, Game.Height - 120);
                        i = 0;
                        Dir.X = -22;
                        Dir.Y = 0;
                        break;


                }
            }

        }
    }
}
