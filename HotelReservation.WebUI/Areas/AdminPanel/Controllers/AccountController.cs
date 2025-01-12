using HotelReservation.WebHelper.ApiHelper;
using HotelReservation.WebHelper.ApiHelper.Result;
using HotelReservation.WebHelper.DTO.Account;
using HotelReservation.WebHelper.SessionHelper;
using HotelReservation.WebUI.Areas.AdminPanel.Models.ViewModels.Login;
using Microsoft.AspNetCore.Http;
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
            LoginViewModel viewModel = new()
            {
                ExceptionMessage = SessionManager.ExceptionMessage
            };
           
            HttpContext.Session.Clear();
            return View(viewModel);
        }

        [HttpPost("/Account/AdminLogin")]
        public async Task<IActionResult> AdminLogin(LoginViewModel loginViewModel)
        {
          

            var client = new RestClient($"{ApiEndpoint.ApiEndpointURL}/Login");
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/Login", Method.Post);
            request.AddBody(loginViewModel.webLoginRequestDTO, "application/json");

            var apiResponse = await client.ExecuteAsync(request);

           

            if (apiResponse.StatusCode==HttpStatusCode.OK)
            {
                var responseObject = JsonSerializer.Deserialize<ApiResult<WebLoginResponseDTO>>(apiResponse.Content);

                SessionManager.loginResponseDTO = responseObject.Data;
                SessionManager.Token = responseObject.Data.Token;
               
                    return Redirect("/Admin/Anasayfa");
                
            }

            SessionManager.ExceptionMessage = "Kullanıcı Adı Veya Şifreniz Yanlış";

            return Redirect("/Admin/Login");
        }
    }
}
