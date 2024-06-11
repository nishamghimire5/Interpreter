using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// Interface for Iterator
    /// </summary>
    internal interface IAbstractIterator
    {
        /// <summary>
        /// Shape's first method
        /// </summary>
        /// <returns></returns>
        Shape First();

        /// <summary>
        /// creating shape class with base interface
        /// </summary>
        /// <returns></returns>
        Shape Next();


    /// <summary>
    /// creating a boolen
    /// </summary>
        bool IsDone { get; }

        /// <summary>
        /// shape's method currentitem
        /// </summary>
        Shape CurrentItem { get; }
    }
}
