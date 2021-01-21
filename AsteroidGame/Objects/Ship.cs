using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Ship : BaseObject
    {
        private readonly Image image = Properties.Resources.ship;
        public int Energy { get; set; } = 100;
        public static event Message MessageDie;
        public static event Message MessageEn;
        public static event Message MessageEnPlus;

        public void EnergyLow(int n)
        {
            Energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
            
        }
        public override void Update()
        {

        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y += Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();

        }
        public void Rob() => MessageEn?.Invoke();
        public void EnPlus() => MessageEnPlus?.Invoke();


    }
}
