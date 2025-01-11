using HotelReservation.WebHelper.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.WebHelper.SessionHelper
{
    public class SessionManager
    {
        public static WebLoginResponseDTO loginResponseDTO 
        {
            get => AppHttpContext.httpContext.Session.GetObject<WebLoginResponseDTO>("WebLoginResponseDTO");
            set => AppHttpContext.httpContext.Session.SetObject("WebLoginResponseDTO", value);
        
        }   
        
        public static string ExceptionMessage 
        {
            get => AppHttpContext.httpContext.Session.GetObject<string>("exceptionMessage");
            set => AppHttpContext.httpContext.Session.SetObject("exceptionMessage", value);
        
        }  
        
        public static string Token 
        {
            get => AppHttpContext.httpContext.Session.GetObject<string>("Token");
            set => AppHttpContext.httpContext.Session.SetObject("Token", value);
        
        }    
    }
}
