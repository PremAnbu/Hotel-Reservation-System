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
            //Using regex Data validation if it will not match meance it will throw custum Exception

            string cust = @"^[a-z]{3,10}$";
            string date = @"^[0-9]{2}[A-Z]{1}[a-z]{2}[0-9]{4}$";

            Console.WriteLine("Enter Customer Type eg : Regular / Rewards");
            string customerType=Console.ReadLine().ToLower();
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

            string format = "ddMMMyyyy";
            DateTime inDate=DateTime.MinValue;
            Console.WriteLine("Enter Check in date -> this formate : 30Sep2024");
            string CheckInDate = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(CheckInDate, date))
                    throw new InvalidDateFormatException("Invalid Date Formate Exception ...");
                inDate = DateTime.ParseExact(CheckInDate, format, CultureInfo.InvariantCulture);

            }
            catch (InvalidDateFormatException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            catch(Exception e)
            {
                Console.WriteLine("Ivalid range of Date please Enter Valid Date Format ---");
                Environment.Exit(1);
            }

            DateTime outDate=DateTime.MinValue;
            Console.WriteLine("Enter check out date -> this formate : 02Oct2024");
            string CheckOutDate = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(CheckOutDate, date))
                    throw new InvalidDateFormatException("Invalid Date Formate Exception ...");
                outDate = DateTime.ParseExact(CheckOutDate, format, CultureInfo.InvariantCulture);

            }
            catch (InvalidDateFormatException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ivalid range of Date please Enter Valid Date Format ---");
                Environment.Exit(1);
            }

            //this foreach loop to store key as a Hotel name and value as a total hotel room rate

            Dictionary<string,int> findHotel = new Dictionary<string,int>();
            foreach (var hotel in allHotelDetails) {
                    int totalRate = CalTotalRate(hotel.Value, inDate, outDate,customerType);
                    findHotel.Add(hotel.Key, totalRate);
            }

            //find low cast of room rate

            int min = int.MaxValue;
            string hotelName = "";
            foreach (var h in findHotel)
            {
                if (min >= h.Value)
                {
                    min = h.Value;
                    hotelName = h.Key;
                }
            }

            //find highest hotel rating 

            int max = 0;
            string hotelName1 = "";

            foreach (var rating in allHotelDetails)
              {
                  if (max < rating.Value.HotelRating)
                  {
                      max = rating.Value.HotelRating;
                      hotelName1 = rating.Key;
                  }
              }
            Console.WriteLine("\n The Cheapest Hotel is {0},Rating : {1} his total amount is {2}\n", hotelName, allHotelDetails[hotelName].HotelRating, min);
            Console.WriteLine(" The Highest Rated Hotel is {0},Rating : {1} his total amount is {2}\n", hotelName1,max, findHotel[hotelName1]);
            Console.WriteLine("============================= Thank You ===== ===========================\n");

        }

        //hear we calculate each hotel total Room Rate
        public int CalTotalRate(HotelPocoClass hotelvalue,DateTime inDate,DateTime outDate ,string customerType )
        {
 
            
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
                int rate = customerType.Equals("regular") ? (weekDays * hotelvalue.WeekdayRegular) + (weekEndDays * hotelvalue.WeekendRegular) :
                        customerType.Equals("rewards") ? (weekDays * hotelvalue.WeekdayRewards) + (weekEndDays * hotelvalue.WeekendRewards) :
                        throw new InvalidCustomerTypeException("Invalid Customer Type Exception ....");
            return rate;
        }
    }
}
