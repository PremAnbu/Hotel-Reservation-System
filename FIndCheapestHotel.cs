using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class FIndCheapestHotel
    {
        public void FindCheapestHotelName(Dictionary<string,HotelPocoClass> allHotelDetails)
        {
           // Console.WriteLine("Enter Customer Type eg : Regular / Rewards");
           // string customerType=Console.ReadLine();
            Console.WriteLine("Enter Check in date eg : 30Sep2024");
            string CheckInDate = Console.ReadLine();
            Console.WriteLine("Enter check out date eg : 02Oct2024");
            string CheckOutDate = Console.ReadLine();

            Dictionary<string,int> findHotel = new Dictionary<string,int>();
            foreach (var hotel in allHotelDetails) {
                int totalRate = CalTotalRate(hotel.Value, CheckInDate, CheckOutDate);
                findHotel.Add(hotel.Key, totalRate);    
                    }
            int min = int.MaxValue;
            string hotelName = "";
            List<string> listOfHotel = new List<string>();
            foreach (var h in findHotel) 
            {
                if(min == h.Value)
                {
                    listOfHotel.Add(h.Key);
                    continue;
                }
                if (min >= h.Value)
                {
                    min = h.Value;
                    hotelName = h.Key;
                }
            }
            if(listOfHotel.Count == 0) 
                Console.WriteLine("THe Cheapest Hotal is {0} his totsl amount is {1}",hotelName,min);
            else
                Console.WriteLine("THe Cheapest Hotal is {0} and {1} his totsl amount is {2}", listOfHotel[0], listOfHotel[1], min);

        }

        //hear we calculate each hotel total Room Rate
        public int CalTotalRate(HotelPocoClass hotelvalue,string checkInDate,string checkoutDate)
        {
            string format = "ddMMMyyyy";
            DateTime inDate = DateTime.ParseExact(checkInDate, format, CultureInfo.InvariantCulture);
            DateTime outDate = DateTime.ParseExact(checkoutDate, format, CultureInfo.InvariantCulture);
            int weekDays = 0;
            int weekEndDays = 0;
            DateTime temp=inDate;
            while (temp<=outDate)
            {
                if (temp.DayOfWeek != DayOfWeek.Sunday && temp.DayOfWeek != DayOfWeek.Saturday)
                    weekDays += 1;
                else
                    weekEndDays += 1;
                Console.WriteLine(temp);
                temp = temp.AddDays(1);
            }
            return (weekDays * hotelvalue.WeekdayRegular) + (weekEndDays * hotelvalue.WeekendRegular);
        }
    }
}
