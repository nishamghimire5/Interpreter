using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_COMP
{
    /// <summary>
    /// shapes exception class to keep all the exceptions
    /// </summary>
    public class ShapesExceptions
    {
        /// <summary>
        /// class for color not found
        /// </summary>
        public class ColorNotFound : Exception
        {
            /// <summary>
            /// color not found method
            /// </summary>
            /// <param name="message"></param>
            public ColorNotFound(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// class for the fill error
        /// </summary>
        public class FillError : Exception
        {
            /// <summary>
            /// fill error method
            /// </summary>
            /// <param name="message"></param>
            public FillError(string message) : base(message)
            {

            }
        }
        /// <summary>
        /// variable not found exception
        /// </summary>
        public class InvalidVariableNameException : Exception
        {
            /// <summary>
            /// invalid variable name exception 
            /// </summary>
            /// <param name="message"></param>
            public InvalidVariableNameException(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// invalid command exception 
        /// </summary>
        public class InvalidCommandException : Exception
        {
            /// <summary>
            /// invalid command exception 
            /// </summary>
            /// <param name="message"></param>
            public InvalidCommandException(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// invalid parameter exception
        /// </summary>
        public class InvalidParameterException : Exception
        {
            /// <summary>
            /// invalid parameter exception
            /// </summary>
            /// <param name="message"></param>
            public InvalidParameterException(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// variable not found exception
        /// </summary>
        public class VariableNotFoundException : Exception
        {
            /// <summary>
            /// variable not found exception
            /// </summary>
            /// <param name="message"></param>
            public VariableNotFoundException(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// invalid method name
        /// </summary>
        public class InvalidMethodNameException : Exception
        {
            /// <summary>
            /// invalid method name
            /// </summary>
            /// <param name="message"></param>
            public InvalidMethodNameException(string message) : base(message)
            {

            }
        }

        /// <summary>
        /// method not found exception
        /// </summary>
        public class MethodNotFoundException : Exception
        {
            /// <summary>
            /// method not found exception
            /// </summary>
            /// <param name="message"></param>
            public MethodNotFoundException(string message) : base(message)
            {

            }
        }
    }
}
