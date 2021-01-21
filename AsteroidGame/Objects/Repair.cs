using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace AsteroidGame.Objects
{
    class Repair: BaseObject
    {
        private readonly Image image = Properties.Resources.apt22;
        //public int Energy { get; set; } = 50;
        public Repair(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Enabled = false;
        }
    }
}
