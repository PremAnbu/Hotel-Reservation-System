using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class CustomException
    {
    }
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string message) : base(message)
        { }
    }
    public class InvalidCustomerTypeException : Exception
    {
        public InvalidCustomerTypeException(string message) : base(message)
        { }
    }
}