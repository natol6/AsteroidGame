using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Star: BaseObject
    {
        private readonly Image image = Properties.Resources.star;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
