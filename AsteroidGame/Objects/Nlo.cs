using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Nlo: BaseObject
    {
        private readonly Image image = Properties.Resources.nlo;
        public Nlo(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < 0 || Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }
    }
}
