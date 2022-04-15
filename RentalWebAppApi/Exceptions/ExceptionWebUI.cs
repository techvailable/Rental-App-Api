using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalWebAppApi.Exceptions
{
    public class ExceptionWebUI : System.Exception
    {
        internal ExceptionWebUI(string message)
               : base(message)
        {
        }

        internal ExceptionWebUI(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
