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
        int i = 0;
        static Image Image { get; } = Image.FromFile("Images\\star.png");
        public StarMain(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            if(i < 3) SplashScreen.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            i++;
            if (i == 6) i = 0;
        }
    }
}
