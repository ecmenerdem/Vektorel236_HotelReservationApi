using HotelReservation.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity
{
    public class Hotel:AuditableEntity
    {
        public Hotel()
        {
           Rooms = new HashSet<Room>();
        }

        //[Required(ErrorMessage = "Bu Alan Zorunludur")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string PhoneNuber { get; set; }
        public string EMail { get; set; }
      


        //Navigation Properties

        public virtual IEnumerable<Room> Rooms { get; set; }


    }
}
