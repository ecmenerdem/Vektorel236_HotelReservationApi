using HotelReservation.Application.Contracts.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["AppSettings:JWTKey"]) ?? throw new ArgumentNullException("Key Bilgisi Gelmedi");

            var tokenDescriptor = new JwtSecurityToken(
                expires:DateTime.Now.AddDays(30),
                claims:claims,
                issuer:"http://asdasd.com",
                signingCredentials:new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature));


            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenDescriptor);
        }
    }
}
