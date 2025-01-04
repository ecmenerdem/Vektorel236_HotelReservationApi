using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
