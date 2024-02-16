using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class HotalReservation
    {
        public static void Main()
        {
            while (true)
            {

                Console.WriteLine("===================== Welcome to Hotel Reservation ===========================\n");
                HotelDetails details = new HotelDetails();
                details.HotelDetail();
                Console.WriteLine("Enter If you want to continue {Y/N}");
                if(!Console.ReadLine().ToLower().Equals("y"))
                {
                    break;
                }
            }
        }
    }
}
