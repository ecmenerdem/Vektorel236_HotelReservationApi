using HotelReservation.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Entity
{
    public class User:AuditableEntity
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

       

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? GroupID { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
        public virtual UserGroup Group { get; set; }

        //public string FullName {


        //    get
        //    {
        //        return FirstName+" "+LastName;
        //    }


        //}

        public string FullName => $"{FirstName} {LastName}";

    }
}
