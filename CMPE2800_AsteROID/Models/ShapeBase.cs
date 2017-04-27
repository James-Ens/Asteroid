using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2800_AsteROID
{
    public abstract class ShapeBase
    {
        //Constant to control the size of shapes
        public const int TILESIZE = 25;
        //Float to hold the current rotation
        public float _rot;
        //Float to hold the rotation change, initialized to 3 for random selection
        public float _rotDelta = -3;
        //Float to hold the x and y speed
        public float _xSpeed = -2.5f;
        public float _ySpeed = -2.5f;
        //Random number constructor
        static public Random _rnd = new Random();
        //Automatic property to hold if the shape is going to die
        public bool IsMarkedForDeath { get; set; }
        //The position of the shape
        public PointF Pos;
        /// <summary>
        /// Constructor to assign the members to the location
        /// </summary>
        /// <param name="location"></param>
        public ShapeBase(PointF location)
        {
            Pos = location;
            _rot = 0;
            //Add to get random numbers between negative and positive float ranges
            _rotDelta += (float)_rnd.NextDouble() * 6;
            _xSpeed += (float)_rnd.NextDouble() * 5;
            _ySpeed += (float)_rnd.NextDouble() * 5;
        }
        /// <summary>
        /// Virtual method that each shape will override
        /// </summary>
        /// <returns></returns>
        public abstract GraphicsPath GetPath();
        /// <summary>
        /// Each shape uses base render to draw the shape
        /// </summary>
        /// <param name="bg"></param>
        public void Render(BufferedGraphics bg, Color col)
        {       
            SolidBrush brush = new SolidBrush(col);
            Pen pen = new Pen(brush);
            //Fill the path with the appropriate brush and path        
            bg.Graphics.FillPath(brush, GetPath());
        }
        /// <summary>
        /// Tick will bounce the shapes off the walls and rotate the shapes
        /// </summary>
        /// <param name="size"></param>
        public void Tick(Size size)
        {
            //Wrap the shapes
            if (Pos.X + TILESIZE < 0)
            {
                Pos.X = size.Width+TILESIZE;
            }
            if(Pos.X - TILESIZE > size.Width)
            {
                Pos.X = 0 - TILESIZE;
            }
            if (Pos.Y - TILESIZE > size.Height)
            {
                Pos.Y = 0 - TILESIZE;
            }
            if (Pos.Y + TILESIZE < 0)
            {
                Pos.Y = size.Height + TILESIZE;
            }
            _rot += _rotDelta;
            Pos = new PointF(Pos.X + _xSpeed, Pos.Y + _ySpeed);
        }
        /// <summary>
        /// Static method that will create triangles or rocks
        /// </summary>
        /// <param name="numVertices"></param>
        /// <param name="smallRadii">smallest radius</param>
        /// <param name="largeRadii">largest radius</param>
        /// <returns></returns>
        public static PointF[] MakeRandomPolygon(int numVertices, int smallRadii, int largeRadii)
        {
            PointF[] points = new PointF[numVertices];
            //Each angle will be a ratio of a whole circle
            float theta = (float)Math.PI * 2 / numVertices;
            float angle = 0;
            for (int i = 0; i < points.Length; i++)
            {
                //Add the tile size to scale it and multiply by the pseudo random radii
                points[i] = new PointF((float)Math.Sin(angle + TILESIZE) * (_rnd.Next(smallRadii, largeRadii)), (float)Math.Cos(angle + TILESIZE) * (_rnd.Next(smallRadii, largeRadii)));
                angle += theta;
            }
            return points;
        }
    }
}
