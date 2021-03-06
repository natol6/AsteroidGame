﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Bullet: BaseObject
    {
        public static event Message MessageBullet;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Enabled = false;
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X > Game.Width) Enabled = false;
        }
        public void Hit()
        {
            Enabled = false;
            MessageBullet?.Invoke();
        }
        
    }
}
