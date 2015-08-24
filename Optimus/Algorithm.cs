using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    abstract class Algorithm
    {
        
        /// <summary>
        /// Processes a file using this algorithm.
        /// </summary>
        /// <param name="fileName">Name of file to process.</param>
        /// <returns>The number of lines processed.</returns>
        public abstract int ProcessFile(string fileName = "");
    }
}
