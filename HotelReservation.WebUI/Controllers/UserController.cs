using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("/Giris")]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
