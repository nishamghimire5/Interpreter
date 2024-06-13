using System.Drawing;

namespace PROJ_COMP
{
    /// <summary>
    /// creating circle class with the base of shape
    /// </summary>
    class Circle : Shape
    {
        /// <summary>
        /// variable of circle class
        /// </summary>
        protected int radius;

        /// <summary>
        /// circle with base of shape
        /// </summary>
        public Circle() : base()
        {

        }

        /// <summary>
        /// overriding the shape's draw method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            //rotating the shape
            if (Form1.RotateShape() != 0)
            {
                float rotateValue = (float)Form1.RotateShape();
                g.RotateTransform((rotateValue));
            }

            //setting pen color to black
            //pen_color = Color.Black;
            Pen p = new Pen(pen_color, 2);
            SolidBrush b = new SolidBrush(fill_color);

            //filling the shape
            if (flag_fill)
            {
                g.FillEllipse(b, x, y, radius, radius);
            }
            else
            {
                g.DrawEllipse(p, x, y, radius, radius);
            }

        }
        /// <summary>
        /// overriding the shape's set_properties method
        /// </summary>
        /// <param name="pen_color"></param>
        /// <param name="c"></param>
        /// <param name="flag_fill"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="num"></param>
        public override void set_properties(Color pen_color, Color c, bool flag_fill, int x, int y, params int[] num)
        {
            base.Set_base(pen_color, c, flag_fill, x, y);
            radius = num[0];
        }
    }
}
