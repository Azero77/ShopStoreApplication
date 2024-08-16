using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Exceptions
{
    public class ModelNumberTakenException : Exception
    {
        public ModelNumberTakenException() : base()
        {
            
        }
        public ModelNumberTakenException(string? message) : base(message)
        {
            
        }
    }
}
