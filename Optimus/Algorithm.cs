using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    abstract class Algorithm
    {
        public abstract void ProcessFile(string fileName = "");
    }
}
