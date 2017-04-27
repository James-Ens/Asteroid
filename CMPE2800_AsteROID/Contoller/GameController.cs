using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Input;
using CMPE2800_AsteROID.Models;
using System.Timers;

namespace CMPE2800_AsteROID.Contoller
{
    public class GameController
    {
        //Properties to hold objects
        public Ship S { get; set; }
        public List<SpaceRock> Rocks = new List<SpaceRock>();
        public List<Bullet> Bullets = new List<Bullet>(8);
        public int Lives { get; set; } = 3;
        public int Level { get; set; } = 1;
        public int Score { get; set; } = 0;
        public bool IsPaused { get; set; } //Determining if the game is paused
        public bool GameOver { get; set; } //Game over flag
        public bool GameStarted { get; set; } //Game started flag
        /// <summary>
        /// Helper method to populate the ship and add initial rocks
        /// </summary>
        /// <param name="ClientSize"></param>
        public void StartGame(Size ClientSize)
        {
            S = new Ship(new PointF(ClientSize.Width / 2, ClientSize.Height / 2));
            for (int i = 0; i < 10; i++)
            {
                Rocks.Add(new SpaceRock(new Point(ShapeBase._rnd.Next(1, ClientSize.Width)
                            , ShapeBase._rnd.Next(1, ClientSize.Height))));
            }

        }
        /// <summary>
        /// Helper method to add more rocks for increased level
        /// </summary>
        /// <param name="ClientSize"></param>
        public void NextLevel(Size ClientSize)
        {
            Score += 500;
            Level++;
            for (int i = 0; i < Level*5+10; i++)
            {
                Rocks.Add(new SpaceRock(new Point(ShapeBase._rnd.Next(1, ClientSize.Width)
                           , ShapeBase._rnd.Next(1, ClientSize.Height))));
            }
        }
        /// <summary>
        /// When shooting is triggered add new bullets
        /// </summary>
        public void Shooting()
        {
            if(Bullets.Count<8)           
                Bullets.Add(new Bullet(S.Pos, S));
        }
        /// <summary>
        /// Helper method to control collision and removing shapes
        /// </summary>
        /// <param name="g"></param>
        public void Collision(Graphics g)
        {
            //Check for bullets hitting rocks
            foreach (var item in Bullets)
            {
                for (int i = 0; i < Rocks.Count; i++)
                {
                    Region bRegion = new Region(item.GetPath());
                    Region rRegion = new Region(Rocks[i].GetPath());
                    bRegion.Intersect(rRegion);
                    if (!bRegion.IsEmpty(g))
                    {
                        item.IsMarkedForDeath = true;
                        Rocks[i].IsMarkedForDeath = true;
                        //Large rocks split into two medium rocks
                        if(Rocks[i]._size == SpaceRock.SizeMult.large)
                        {
                            Score += 100;
                            Rocks.Add(new SpaceRock(new PointF(Rocks[i].Pos.X, Rocks[i].Pos.Y - 5), SpaceRock.SizeMult.medium));
                            Rocks.Add(new SpaceRock(new PointF(Rocks[i].Pos.X, Rocks[i].Pos.Y + 5), SpaceRock.SizeMult.medium));
                        }
                        //Medium rocks split into two small rocks
                        if(Rocks[i]._size == SpaceRock.SizeMult.medium)
                        {
                            Score += 200;
                            Rocks.Add(new SpaceRock(new PointF(Rocks[i].Pos.X, Rocks[i].Pos.Y - 5), SpaceRock.SizeMult.small));
                            Rocks.Add(new SpaceRock(new PointF(Rocks[i].Pos.X, Rocks[i].Pos.Y + 5), SpaceRock.SizeMult.small));
                        }
                        else
                        {
                            Score += 300;
                        }
                    }
                }               
            }
            //check rocks vs Ship
            //Only check rocks with max alpha value
            List<SpaceRock> fullRocks = new List<SpaceRock>();
            fullRocks = (from q
                         in Rocks
                         where q.Fade == 254
                         select q).ToList();
            foreach (var item in fullRocks)
            {
                Region sRegion = new Region(S.GetPath());
                Region rRegion = new Region(item.GetPath());
                sRegion.Intersect(rRegion);
                if (!sRegion.IsEmpty(g))
                {
                    //Game Over Screen
                    item.IsMarkedForDeath = true;
                    S.IsMarkedForDeath = true;
                    Lives--;
                    //Run out of lives and the game ends
                    if (Lives == 0)
                    {
                        GameOver = true;
                        return;
                    }
                }
            }
            //Remove dead shapes
            Rocks.RemoveAll(x => x.IsMarkedForDeath);
            Bullets.RemoveAll(x => x.IsMarkedForDeath);
        }
    }
}
