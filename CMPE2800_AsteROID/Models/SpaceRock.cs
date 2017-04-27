using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CMPE2800_AsteROID
{
    public class SpaceRock : ShapeBase
    {
        /// <summary>
        /// Enum type to differentiate between small, medium, and large rocks for scoring
        /// </summary>
        public enum SizeMult { small=1, medium, large };
        public SizeMult _size;
        //The graphics path member for each Rock
        public GraphicsPath _model = new GraphicsPath();
        public int Fade { get; set; } = 0;
        /// <summary>
        /// Constructor to assign location and build shape
        /// </summary>
        /// <param name="location"></param>
        public SpaceRock(PointF location) : base(location)
        {
            _size = (SizeMult)_rnd.Next(1,4);    
            _model.AddPolygon(MakeRandomPolygon(_rnd.Next(4, 13), (int)_size * TILESIZE / 2, (int)_size * TILESIZE));
        }
        /// <summary>
        /// Constructor to assign location and build shape
        /// </summary>
        /// <param name="location"></param>
        public SpaceRock(PointF location, SizeMult size) : base(location)
        {
            _size = size;
            _model.AddPolygon(MakeRandomPolygon(_rnd.Next(4, 13), (int)_size * TILESIZE / 2, (int)_size * TILESIZE));
        }
        /// <summary>
        /// Override of GetPath method to assign shape and transform the graphics path
        /// </summary>
        /// <returns></returns>
        public override GraphicsPath GetPath()
        {
            GraphicsPath temp = (GraphicsPath)_model.Clone();

            Matrix mat = new Matrix();

            mat.Translate(Pos.X, Pos.Y);
            mat.Rotate(_rot);

            temp.Transform(mat);
            return temp;
        }
        /// <summary>
        /// Tick will bounce the shapes off the walls and rotate the shapes
        /// </summary>
        /// <param name="size"></param>
        public new void Tick(Size size)
        {
            //Fade in Rocks
            if(Fade < 254)
                Fade += 2;
            //Wrap the shapes
            //Grab back edge of shapes and move to just outside of window
            if (Pos.X + ((int)_size * TILESIZE) < 0)
            {
                Pos.X = size.Width + ((int)_size * TILESIZE);
            }
            if (Pos.X - ((int)_size * TILESIZE) > size.Width)
            {
                Pos.X = 0 - ((int)_size * TILESIZE);
            }
            if (Pos.Y - ((int)_size * TILESIZE) > size.Height)
            {
                Pos.Y = 0 - ((int)_size * TILESIZE);
            }
            if (Pos.Y + ((int)_size * TILESIZE) < 0)
            {
                Pos.Y = size.Height + ((int)_size * TILESIZE);
            }
            _rot += _rotDelta;
            Pos = new PointF(Pos.X + _xSpeed, Pos.Y + _ySpeed);
        }
    }
}
