using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelReservation.Application.DTO.User
{
    public class LoginResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Username { get; set; }

        public string Token { get; set; }

        public string Fullname {

            get
            {

            return FirstName+" " +LastName; 
            
            }
            
        
        
        }

    }
}
