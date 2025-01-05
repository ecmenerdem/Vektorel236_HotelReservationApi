using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.WebHelper
{


    public class AppHttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static HttpContext httpContext => _httpContextAccessor?.HttpContext;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
