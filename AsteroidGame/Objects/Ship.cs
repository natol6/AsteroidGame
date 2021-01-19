﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.Objects
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        private readonly Image image = Properties.Resources.ship;
        public int Energy => _energy;
        public static event Message MessageDie;

        public void EnergyLow(int n)
        {
            _energy -= n;
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
        

    }
}
