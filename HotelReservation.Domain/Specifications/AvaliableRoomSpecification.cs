using HotelReservation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Specifications
{
    public class AvaliableRoomSpecification
    {
        public bool IsAvalibleForPurchase(Room room, DateTime chekInDate, DateTime checkOutDate)
        {
            return room.IsAvalible && chekInDate < checkOutDate && room.IsActive == true && room.IsDeleted == false;
        }
    }
}
