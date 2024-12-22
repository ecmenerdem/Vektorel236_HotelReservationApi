using HotelReservation.API.Common;
using HotelReservation.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<JWTExceptURLList> _jwtExceptURLList;
        public ApiAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration, IOptionsMonitor<JWTExceptURLList> jwtExceptURLList)
        {
            _next = next;
            _configuration = configuration;
            _jwtExceptURLList = jwtExceptURLList;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestURL = httpContext.Request.Path;

            if (!_jwtExceptURLList.CurrentValue.URLList.Contains(requestURL))
            {
                var jwtHandler = new JwtSecurityTokenHandler();

                string authHeader = httpContext.Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(authHeader))
                {
                    var token = authHeader.Replace("Bearer ", "");

                    var key = Encoding.UTF8.GetBytes(_configuration["AppSettings:JWTKey"]) ?? throw new ArgumentNullException("Key Bilgisi Gelmedi");

                    jwtHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    }, out SecurityToken validatedToken);


                    var jwtToken = (JwtSecurityToken)validatedToken;

                    if (jwtToken.ValidTo < DateTime.Now)
                    {
                        throw new SecurityTokenException("Token Tarihi Geçersiz");
                    }
                }

                else
                {
                    throw new TokenNotFoundException();
                }
            }

           


            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiAuthorizationMiddleware>();
        }
    }
}
