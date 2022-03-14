using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBookingAPI.Models
{
    public class BookingDetail
    {

        //public long Id { get; set; }
        //public bool IsComplete { get; set; }
        public string BookingDate { get; set; }
        public string Time { get; set; }
        public string PickUpPoint { get; set; }     //(Free text, for example: Ang Mo Kio Hub)
        public string Destination { get; set; }   //(Free text, for example: Sun Plaza)
        public Double Current_Location_Latitude { get; set; }    //(for example: 1.3581)
        public Double Current_Location_Longitude { get; set; }   //(for example: 103.8956)

    }
}
