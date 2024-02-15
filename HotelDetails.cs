using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class HotelDetails
    {
        public void HotelDetail()
        {
            Dictionary<string, HotelPocoClass> hoteldetail = new Dictionary<string, HotelPocoClass>();

            hoteldetail.Add("Lakewood", new HotelPocoClass
            {
                HotelName = "Lakewood",HotelRating = 3,
                WeekdayRegular = 1100, WeekdayRewards = 800,
                WeekendRegular = 900, WeekendRewards = 800
            });

            hoteldetail.Add("Bridgewood", new HotelPocoClass
            {
                HotelName = "Bridgewood", HotelRating = 4,
                WeekdayRegular = 1600, WeekdayRewards = 1100,
                WeekendRegular = 600, WeekendRewards = 500
            });

            hoteldetail.Add("Ridgewood", new HotelPocoClass
            {
                HotelName = "Ridgewood", HotelRating = 5,
                WeekdayRegular = 2200, WeekdayRewards= 1000,
                WeekendRegular= 1500, WeekendRewards= 400
            });
        }
    }
}
