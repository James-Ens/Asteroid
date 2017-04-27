using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using Input;
using CMPE2800_AsteROID.Models;

namespace CMPE2800_AsteROID.Models
{
    /// <summary>
    /// Bullet class 
    /// </summary>
    public class Bullet : ShapeBase
    {
        //Constant to hold the speed of the bullet
        public const int BULLETSPEED = 5;
        //The graphics path member for each Rock
        public GraphicsPath _model = new GraphicsPath();
        /// <summary>
        /// Constructor to assign the members to the location
        /// </summary>
        /// <param name="location"></param>
        public Bullet(PointF location, Ship s) :base(location)
        {
            //Initialize the position of the bullet to the tip of the ship
            Pos = new PointF(s.Pos.X + (float)Math.Sin(Math.PI / 180 * s._rot + Math.PI) * Ship.SHIPSIZE,
                s.Pos.Y + (float)Math.Cos(Math.PI / 180 * s._rot + Math.PI) * -Ship.SHIPSIZE);
            //Calculate the x and y trajectory based on ship rotation
            float angle = (float)(s._rot * (Math.PI / 180.0));
            _xSpeed = (float)Math.Sin(angle) * BULLETSPEED * -1;
            _ySpeed = (float)Math.Cos(angle) * BULLETSPEED;
            _model.AddEllipse(0,0,2.5f,2.5f);
        }
        public override GraphicsPath GetPath()
        {
            GraphicsPath temp = (GraphicsPath)_model.Clone();
            Matrix mat = new Matrix();
            mat.Translate(Pos.X ,Pos.Y);
            temp.Transform(mat);
            return temp;
        }
        /// <summary>
        /// Method to update bullet position and mark ones on the edge for death
        /// </summary>
        /// <param name="size"></param>
        /// <param name="s"></param>
        public void MoveBullet(Size size, Ship s)
        {
            if(Pos.X<0 || Pos.X>size.Width)
            {
                IsMarkedForDeath = true;
            }
            if(Pos.Y<0 || Pos.Y>size.Height)
            {
                IsMarkedForDeath = true;
            }
            Pos = new PointF(Pos.X + _xSpeed, Pos.Y + _ySpeed);
        }
    }
}
