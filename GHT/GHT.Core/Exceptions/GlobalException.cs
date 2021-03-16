using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Core.Exceptions
{
     public class GlobalException : Exception
    {
        public GlobalException()
        {

        }

        public GlobalException(string message) : base(message)
        {

        }
    }
}
