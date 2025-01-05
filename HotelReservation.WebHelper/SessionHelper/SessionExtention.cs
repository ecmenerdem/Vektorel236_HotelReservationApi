using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelReservation.WebHelper.SessionHelper
{
    public static class SessionExtention
    {
        public static void SetObject(this ISession session, string key, object? value)
        {
            var stringValue = JsonSerializer.Serialize(value);
            session.SetString(key, stringValue);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value is null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
