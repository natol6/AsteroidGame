using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class StarMain: BaseObject
    {
        private int i = 0;
        private readonly Image image = Properties.Resources.star;
        public StarMain(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            if(i < 3) SplashScreen.__buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            i++;
            if (i == 6) i = 0;
        }
    }
}
