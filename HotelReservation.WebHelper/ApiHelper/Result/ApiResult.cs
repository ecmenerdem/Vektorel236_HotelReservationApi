using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelReservation.WebHelper.ApiHelper.Result
{
    public class ApiResult<TResponse>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TResponse? Data { get; set; }
        public ErrorResult Error { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }
}
