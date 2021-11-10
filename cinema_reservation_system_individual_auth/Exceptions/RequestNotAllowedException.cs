using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_reservation_system_individual_auth.Exceptions
{
    public class RequestNotAllowedException : Exception
    {
        public RequestNotAllowedException(string message) : base(message)
        {
            
        }
    }
}
