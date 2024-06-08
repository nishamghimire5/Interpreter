using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// Factory class of the shape class
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Method checks either which shapes are included in the system
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Shape GetShape(String name)
        {
            name = name.ToLower().Trim();

            if (name.Equals("circle"))
            {
                return new Circle();
            }
            else if (name.Equals("rectangle"))
            {
                return new Rectangle();
            }
            else if (name.Equals("triangle"))
            {
                return new Triangle();
            }
            else if (name.Equals("polygon"))
            {
                return new Polygon();
            }

            else
            {

                System.ArgumentException names = new System.ArgumentException("Factory Error: " + name + " shape isn't in our system currently");
                throw names;
            }


        }
    }
}
