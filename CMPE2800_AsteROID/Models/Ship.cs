using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using Input;

namespace CMPE2800_AsteROID
{
    public class Ship : ShapeBase
    { 
    //Constant to control the size of the ships
    public const int SHIPSIZE = 25;
    //The graphics path member for each Rock
    public GraphicsPath _model = new GraphicsPath();
    //The graphics path for the exhaust
    public GraphicsPath _exhaust = new GraphicsPath();
    public bool boost { get; set; }
    public bool GodMode { get; set; }
    /// <summary>
    /// Constructor to assign the members to the location
    /// </summary>
    /// <param name="location"></param>
    public Ship(PointF location) :base(location)
    {
        _model.AddPolygon(MakeShip());
       // _exhaust.AddPolygon(Exhaust());
    }
    public PointF[] MakeShip()
    {
        PointF[] points = new PointF[4];
        float theta = (float)Math.PI * 2 / 3;
        //Angle the engine point will be offset width wise
        float shipAngleWidth = theta / 2f;
        //Angle the engine point will be offset height wise
        float shipAngleHeight = 0.4f;
        //First point is bottom or tip
        points[0] = new PointF((float)Math.Sin(theta), (float)Math.Cos(theta));
        //The Engine Point
        points[1] = new PointF((float)Math.Sin(theta * 2 - shipAngleWidth), (float)Math.Cos(theta * 2 + shipAngleHeight));
        //Top Left
        points[2] = new PointF((float)Math.Sin(theta * 2), (float)Math.Cos(theta * 2));
        //Top right
        points[3] = new PointF((float)Math.Sin(theta * 3), (float)Math.Cos(theta * 3));
        return points;
    }
    /// <summary>
    /// Exhaust triangle for boost
    /// </summary>
    /// <returns></returns>
    private PointF[] Exhaust()
    {
        PointF[] points = new PointF[3];
        float theta = (float)Math.PI * 2 / 3;
        points[0] = new PointF((float)Math.Sin(theta), (float)Math.Cos(theta) - 2);
        points[1] = new PointF((float)Math.Sin(theta * 2), (float)Math.Cos(theta * 2) - 2);
        points[2] = new PointF((float)Math.Sin(theta * 3), (float)Math.Cos(theta * 3) - 2);
        return points;
    }
        /// <summary>
        /// Each shape uses base render to draw the shape
        /// </summary>
        /// <param name="bg"></param>
        public new void Render(BufferedGraphics bg, Color col)
        {
            base.Render(bg, col);
            //Fill the path with the appropriate brush and path  
            GraphicsPath ship = GetPath();
            if (boost)
                ship.AddPath(GetExhaust(), false);
        }
        public override GraphicsPath GetPath()
    {
        GraphicsPath temp = (GraphicsPath)_model.Clone();

        Matrix mat = new Matrix();

        mat.Translate(Pos.X, Pos.Y);
        mat.Rotate(_rot);
        mat.Scale(SHIPSIZE, SHIPSIZE);

        temp.Transform(mat);
        return temp;
    }
    public GraphicsPath GetExhaust()
    {
        GraphicsPath temp = (GraphicsPath)_exhaust.Clone();

        Matrix mat = new Matrix();
        mat.Translate(Pos.X, Pos.Y);
        mat.Rotate(_rot);
        mat.Scale(SHIPSIZE / 2, SHIPSIZE / 2);

        temp.Transform(mat);
        return temp;
    }
    public void MoveShip(InputInterface i)
    {

        if (i._right)
        {
            _rot += 6.0f;
        }
        else if (i._left)
        {
            _rot -= 6.0f;
        }        
    }
}
}