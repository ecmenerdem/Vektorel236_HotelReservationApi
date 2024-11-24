using HotelReservation.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity
{
    public class Reservation:AuditableEntity
    {
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuest { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual User User { get; set; }

        public virtual Room Room { get; set; }
    }
}
