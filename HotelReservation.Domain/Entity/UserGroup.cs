using HotelReservation.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity
{
    public class UserGroup:AuditableEntity
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
