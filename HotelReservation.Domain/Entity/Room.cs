using HotelReservation.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity
{
    public class Room:AuditableEntity
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int HotelID { get; set; }
        public int RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvalible { get; set; }
        public string Desciption { get; set; }
     

        //Navigation Properties

        public virtual Hotel Hotel { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}
