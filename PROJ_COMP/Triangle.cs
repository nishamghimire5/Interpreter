using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// new class rectangle is created from te base class shape
    /// </summary>
    internal class Triangle : Shape
    {
        int side1;
        int side2;
        int side3;
        /// <summary>
        ///  calling  the base class constructor
        /// </summary>
        public Triangle() : base()
        {

        }

        /// <summary>
        /// overriding the draw method from shape
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            if (Form1.RotateShape() != 0)
            {
                float rotateValue = (float)Form1.RotateShape();
                g.RotateTransform((rotateValue), MatrixOrder.Append);
            }

            Pen p = new Pen(pen_color, 2);

            SolidBrush b = new SolidBrush(fill_color);
            PointF[] points = new PointF[3];


            points[0].X = x;
            points[0].Y = y;

            points[1].X = x + side1;
            points[1].Y = y;

            points[2].X = x + side3;
            points[2].Y = y + side2;

            if (flag_fill)
            {
                g.FillPolygon(b, points);
            }
            else
            {
                g.DrawPolygon(p, points);
            }


        }

        /// <summary>
        /// overriding the set_properties of shape and setting triangle's properties
        /// </summary>
        /// <param name="pen_color"></param>
        /// <param name="fill_color"></param>
        /// <param name="flag_fill"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="list"></param>
        public override void set_properties(Color pen_color, Color fill_color, bool flag_fill, int x, int y, params int[] list)
        {
            side1 = list[0];
            side2 = list[1];
            side3 = list[2];

            base.Set_base(pen_color, fill_color, flag_fill, x, y);
        }
    }
}
