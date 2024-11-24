using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity.Base
{
    public class AuditableEntity:BaseEntity
    {
        public int? AddedUser { get; set; }
        public DateTime? AddedTime { get; set; }
        public string? AddedIP { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string? UpdatedIP { get; set; }
    }
}
