using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// creating base class InterfaceShape
    /// </summary>
    internal interface InterfaceShape
    {
        /// <summary>
        /// setting properties method
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="cl"></param>
        /// <param name="flag_fill"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="num"></param>
        void set_properties(Color c1, Color cl, Boolean flag_fill, int x, int y, params int[] num);

        /// <summary>
        /// seting set base method
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="cl"></param>
        /// <param name="flag_fill"></param>
        /// <param name="num"></param>
        void Set_base(Color c2, Color cl, bool flag_fill, params int[] num);

        /// <summary>
        /// method to draw shapes
        /// </summary>
        /// <param name="g"></param>
        void draw(Graphics g);
    }
}
