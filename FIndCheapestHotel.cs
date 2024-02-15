using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    public class FIndCheapestHotel
    {
        public void FindCheapestHotelName(Dictionary<string,HotelPocoClass> allHotelDetails)
        {
            string cust = @"^[A-Z]{1}[a-z]{3,}$";
            string date = @"^[0-9]{2}[A-Z]{1}[a-z]{2}[0-9]{4}$";
            Console.WriteLine("Enter Customer Type eg : Regular / Rewards");
            string customerType=Console.ReadLine();
            try {
                if (!Regex.IsMatch(customerType, cust))
                {
                    throw new InvalidCustomerTypeException("Invalid Customer Type Exception ...");
                }
            }
            catch (InvalidCustomerTypeException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            Console.WriteLine("Enter Check in date -> this format : 30Sep2024");
            string CheckInDate = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(CheckInDate, date))
                    throw new InvalidDateFormatException("Invalid Date Formate Exception ...");
            }
            catch (InvalidDateFormatException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            Console.WriteLine("Enter check out date -> this format : 02Oct2024");
            string CheckOutDate = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(CheckOutDate, date))
                    throw new InvalidDateFormatException("Invalid Date Formate Exception ...");
            }
            catch (InvalidDateFormatException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

            Dictionary<string,int> findHotel = new Dictionary<string,int>();
            foreach (var hotel in allHotelDetails) {
                    int totalRate = CalTotalRate(hotel.Value, CheckInDate, CheckOutDate,customerType);
                    findHotel.Add(hotel.Key, totalRate);
            }
            int min = int.MaxValue;
            string hotelName = "";
           // int max = 0;
            foreach (var h in findHotel)
            {
                if (min >= h.Value)
                {
                    min = h.Value;
                    hotelName = h.Key;
                }
            }
            /*  foreach(var rating in allHotelDetails)
              {
                  if (max < rating.Value.HotelRating)
                  {
                      max = rating.Value.HotelRating;
                      hotelName = rating.Key;
                  }
              }*/
            Console.WriteLine("THe Cheapest Hotal is {0},Rating : {1} his totsl amount is {2}", hotelName, allHotelDetails[hotelName].HotelRating, min);

        }

        //hear we calculate each hotel total Room Rate
        public int CalTotalRate(HotelPocoClass hotelvalue,string checkInDate,string checkoutDate ,string customerType )
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
               // Console.WriteLine(temp);
                temp = temp.AddDays(1);
            }
                int rate = customerType.Equals("Regular") ? (weekDays * hotelvalue.WeekdayRegular) + (weekEndDays * hotelvalue.WeekendRegular) :
                        customerType.Equals("Rewards") ? (weekDays * hotelvalue.WeekdayRewards) + (weekEndDays * hotelvalue.WeekendRewards) :
                        throw new InvalidCustomerTypeException("Invalid Customer Type Exception ....");
            return rate;
        }
    }
}
