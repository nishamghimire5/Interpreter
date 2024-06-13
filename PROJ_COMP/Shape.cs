using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// creating class shape with the base class interfaceshape
    /// </summary>
    public abstract class Shape : InterfaceShape
    {
        /// <summary>
        /// protecting the color to fill the shape
        /// </summary>
        protected Color fill_color;

        /// <summary>
        /// assigning the pen color
        /// </summary>
        protected Color pen_color;

        /// <summary>
        /// protecting the x and y variable for axis
        /// </summary>
        protected int x, y;

        /// <summary>
        /// variable to eaither fill or not fill the shape
        /// </summary>
        protected bool flag_fill;


        /// <summary>
        /// shape constructor
        /// </summary>
        public Shape()
        {
            pen_color = Color.Black;
            x = y = 0;
        }


        /// <summary>
        /// draw method
        /// </summary>
        /// <param name="g"></param>
        public abstract void draw(Graphics g);


        /// <summary>
        /// creating method set_base 
        /// </summary>
        /// <param name="pen_color"></param>
        /// <param name="c"></param>
        /// <param name="flag_fill"></param>
        /// <param name="num"></param>
        public virtual void Set_base(Color pen_color, Color c, bool flag_fill, params int[] num)
        {
            fill_color = c;
            this.pen_color = pen_color;
            this.flag_fill = flag_fill;
            x = num[0];
            y = num[1];
        }

        /// <summary>
        /// creating set_properties method
        /// </summary>
        /// <param name="pen_color"></param>
        /// <param name="fill_color"></param>
        /// <param name="flag_fill"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="num"></param>
        public abstract void set_properties(Color pen_color, Color fill_color, bool flag_fill, int x, int y, params int[] num);
    }

}
