﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AsteroidGame.Objects;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __context;
        internal static BufferedGraphics __buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static readonly Image __background = Properties.Resources.fon1;
        private static BaseObject[] __objs;
        private static Asteroid[] __asteroids;
        private static Bullet __bullet;
        private static Ship __ship;
        private static Repair __repair;
        private static Timer __timerRep = new Timer();
        static Game()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            __context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            __buffer = __context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            __timerRep.Interval = 30000;
            __timerRep.Tick += TimerRep_Tick;
            __timerRep.Start();
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void TimerRep_Tick(object sender, EventArgs e)
        {
            if (__repair == null || !__repair.Enabled) __repair = new Repair(new Point(Width, Program.rnd.Next(20, Height - 20)), new Point(-10, 0), new Size(20, 20));
            
        }
        public static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) __bullet = new Bullet(new Point(__ship.Rect.X + 20, __ship.Rect.Y + 20), new Point(5, 0), new Size(5, 2));
            if (e.KeyCode == Keys.I) __ship.Up();
            if (e.KeyCode == Keys.J) __ship.Down();
            
        }
        
        public static void Draw()
        {
            
            __buffer.Graphics.DrawImage(__background, 0, 0, Width, Height);
            foreach (BaseObject obj in __objs)
                if (obj.Enabled) obj.Draw();
            foreach (Asteroid ast in __asteroids)
                if(ast.Enabled) ast.Draw();
            if (__bullet.Enabled) __bullet.Draw();
            if (__ship.Enabled) __ship.Draw();
            if (__repair.Enabled) __repair.Draw();
            MainForm mf = Application.OpenForms[0] as MainForm;
            __buffer.Graphics.DrawString("Пилот: " + mf.Nik(), SystemFonts.DefaultFont, Brushes.Orange, 0, 0);
            __buffer.Render();

        }
        public static void Update()
        {
            foreach (BaseObject obj in __objs)
                if (obj != null && obj.Enabled) obj.Update();
            if (__bullet != null && __bullet.Enabled) __bullet.Update();
            if (__repair != null && __repair.Enabled) __repair.Update();
            if (__ship.Enabled && __repair.Enabled && __ship.Collision(__repair))
            {
                System.Media.SystemSounds.Beep.Play();
                __repair.Enabled = false;
                if (__ship.Energy < 50) __ship.Energy += 50;
                else __ship.Energy = 100;
                __ship.EnPlus();
            }
            for (var i = 0; i < __asteroids.Length; i++)
            {
                if (!__asteroids[i].Enabled) continue;
                __asteroids[i].Update();
                if (__bullet.Enabled && __bullet.Collision(__asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    __bullet.Hit();
                    __asteroids[i].Enabled = false;
                    __bullet.Enabled = false;

                    continue;
                }
                if (__ship.Enabled && !__ship.Collision(__asteroids[i])) continue;
                __ship.EnergyLow(__asteroids[i].Power);
                __ship.Rob();
                System.Media.SystemSounds.Asterisk.Play();
                if (__ship.Energy <= 0) __ship.Die();
            }
            
               

        }
        public static int EnergyShip() => __ship.Energy;
        
        public static void Load()
        {
            __objs = new BaseObject[150];
            __asteroids = new Asteroid[15];
            __objs[0] = new Comet(new Point(Game.Width, 100), new Point(-25, 0), new Size(100, 100));
            for (int i = 1; i < 3; i++)
                __objs[i] = new Nlo(new Point(Program.rnd.Next(10, Width - 10), Program.rnd.Next(10, Height - 10)), new Point(Program.rnd.Next(5, 15), Program.rnd.Next(5, 15)), new Size(50, 42));
            for (int i = 3; i < __objs.Length; i++)
                __objs[i] = new Star(new Point(Program.rnd.Next(0, Width), Program.rnd.Next(0, Height)), new Point(-Program.rnd.Next(1, 20), 0), new Size(i + 1, i + 1));
            for (int i = 0; i < __asteroids.Length; i++)
            {
                switch (Program.rnd.Next(1, 4))
                {
                    case 1:
                        __asteroids[i] = new Asteroid(new Point(Width, Program.rnd.Next(20, Height - 20)), new Point(Program.rnd.Next(-20, -6), Program.rnd.Next(-10, 11)), new Size(60, 60));
                        break;

                    case 2:
                        __asteroids[i] = new Asteroid(new Point(Program.rnd.Next(Width / 3, Width), 0), new Point(Program.rnd.Next(-20, -6), Program.rnd.Next(1, 11)), new Size(20, 20));
                        break;

                    case 3:
                        __asteroids[i] = new Asteroid(new Point(Program.rnd.Next(Width / 3, Width), Height), new Point(Program.rnd.Next(-20, -6), Program.rnd.Next(-11, -1)), new Size(40, 40));
                        break;
                }
                 
            
            }
            __ship = new Ship(new Point(30, (int)(Height / 2)), new Point(5, 5), new Size(15, 15));
            __bullet = new Bullet(new Point(__ship.Rect.X + 20, __ship.Rect.Y + 20), new Point(5, 0), new Size(5, 2));
            __repair = new Repair(new Point(Width, Program.rnd.Next(20, Height - 20)), new Point(-10, 0), new Size(20, 20));
            __repair.Enabled = false;
            
        }
        
    }
}