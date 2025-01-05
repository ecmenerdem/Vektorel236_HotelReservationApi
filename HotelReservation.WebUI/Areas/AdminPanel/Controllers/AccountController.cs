using HotelReservation.WebHelper.ApiHelper.Result;
using HotelReservation.WebHelper.DTO.Account;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace HotelReservation.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        [HttpGet("/Admin/Login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost("/Account/AdminLogin")]
        public async Task<IActionResult> AdminLogin(WebLoginRequestDTO loginRequestDTO)
        {
            List<string> roles = new() { "Admin", "Muhasebe" };

            var client = new RestClient("http://localhost:5211/Login");
            var request = new RestRequest("http://localhost:5211/Login", Method.Post);
            request.AddBody(loginRequestDTO, "application/json");

            var apiResponse = await client.ExecuteAsync(request);

           

            if (apiResponse.StatusCode==HttpStatusCode.OK)
            {
                var responseObject = JsonSerializer.Deserialize<ApiResult<WebLoginResponseDTO>>(apiResponse.Content);

                if (roles.Contains(responseObject.Data.GrupAdi)) {
                    return Redirect("/Admin/Anasayfa");
                }

                ViewData["LoginError"] = "Yetkisiz bir Sayfaya Erişmeye Çalıştınız.";
                return View("LoginPage");
            }

            ViewData["LoginError"] = "Kullanıcı Adı Veya Şifreniz Yanlış";

            return View("LoginPage");
        }
    }
}
