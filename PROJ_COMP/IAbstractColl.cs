using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// interface abstract collection
    /// </summary>
    internal interface IAbstractColl
    {
        /// <summary>
        /// creating iterator
        /// </summary>
        /// <returns></returns>
        Iterator CreateIterator();
    }
}
