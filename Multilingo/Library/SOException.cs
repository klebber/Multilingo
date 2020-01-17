using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SOException : Exception
    {
        public SOException(string message) : base(message)
        {
        }
    }
}
