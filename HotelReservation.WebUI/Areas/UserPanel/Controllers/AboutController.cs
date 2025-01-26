using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]

    public class AboutController : Controller
    {
        [HttpGet("/Hakkimizda")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
