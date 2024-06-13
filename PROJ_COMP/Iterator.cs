using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// creating iterator class having base interface IAbstractIterator
    /// </summary>
    internal class Iterator : IAbstractIterator
    {
        private ArrayList shape_list = Form1.shape_list;

        private int current = 0;
        private int step = 1;


        /// <summary>
        /// method to use in IAbstractColl
        /// </summary>
        public Shape CurrentItem
        {
            get { return shape_list[current] as Shape; }
        }

        /// <summary>
        /// method to use in IAbstractColl
        /// </summary>
        /// <returns></returns>
        public Shape First()
        {
            current = 0;
            return shape_list[current] as Shape;
        }

        /// <summary>
        /// method to use in IAbstractColl
        /// </summary>
        public bool IsDone
        {
            get { return current >= shape_list.Count; }
        }

        /// <summary>
        /// method to use in IAbstractColl
        /// </summary>
        /// <returns></returns>
        public Shape Next()
        {
            current += step;
            if (!IsDone)
                return shape_list[current] as Shape;
            else
                return null;
        }
        /// <summary>
        /// method step with datatype int
        /// </summary>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
    }
  
 

}
