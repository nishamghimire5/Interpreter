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
    /// creating rectangle class from the base class shape
    /// </summary>
    class Rectangle : Shape
    {
        int height;
        int width;
        /// <summary>
        /// rectangle with base shape
        /// </summary>
        public Rectangle() : base()
        {

        }

        //public Rectangle(int height, int width, Color c1, Color c2, int x, int y) : base(c1, c2, x, y)
        //{
        //    // height and width is different 
        //    this.height = height;
        //    this.width = width;
        //}


        /// <summary>
        /// setting properties of rectangle overriding the shape's
        /// </summary>
        /// <param name="pen_color"></param>
        /// <param name="fill_color"></param>
        /// <param name="flag_fill"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="num"></param>
        public override void set_properties(Color pen_color, Color fill_color, Boolean flag_fill, int x, int y, params int[] num)
        {
            this.width = num[0];
            this.height = num[1];

            base.Set_base(pen_color, fill_color, flag_fill, x, y);
        }

        /// <summary>
        /// setting the draw method overriding the shape's
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            if (Form1.RotateShape() != 0)
            {
                float rotateValue = (float)Form1.RotateShape();
                g.RotateTransform((rotateValue), MatrixOrder.Append);
            }

            Pen p = new Pen(pen_color);

            g.DrawRectangle(p, x, y, width, height);

            RectangleF rect = new RectangleF(x, y, width, height);


            if (flag_fill == true)
            {
                SolidBrush blueBrush = new SolidBrush(fill_color);

                g.FillRectangle(blueBrush, rect);
            }

        }
    }
}
