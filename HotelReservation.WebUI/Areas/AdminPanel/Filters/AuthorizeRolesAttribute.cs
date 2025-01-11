using HotelReservation.WebHelper.Exceptions;
using HotelReservation.WebHelper.SessionHelper;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelReservation.WebUI.Areas.AdminPanel.Filters
{
    public class AuthorizeRolesAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeRolesAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = SessionManager.loginResponseDTO;
            if (user == null || !_roles.Contains(user.GrupAdi))
            {
                throw new UnauthorizeUserException();
            }
        }
    }
}
