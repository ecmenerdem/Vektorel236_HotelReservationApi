using HotelReservation.WebHelper.ApiHelper;
using HotelReservation.WebHelper.ApiHelper.Result;
using HotelReservation.WebHelper.DTO.User;
using HotelReservation.WebHelper.SessionHelper;
using HotelReservation.WebUI.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace HotelReservation.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AuthorizeRoles("Admin", "Muhasebe")]
    public class UserController : Controller
    {

        [HttpGet("/Admin/Kullanicilar")]
        public async Task<IActionResult> Index()
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/Users", Method.Get);

            request.AddHeader("Authorization","Bearer "+SessionManager.Token);


            var apiResponse = await client.ExecuteAsync(request);

                var responseObject = JsonSerializer.Deserialize<ApiResult<List<UserDetailDTO>>>(apiResponse.Content);

            return View(responseObject.Data);
           
        }

        [HttpGet("/Admin/User/{guid}")]
        public async Task<IActionResult> GetUserDetail(Guid guid)
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/User/"+guid, Method.Get);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);


            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<UserDetailDTO>>(apiResponse.Content);

            var user = responseObject.Data;

            if (apiResponse.StatusCode==HttpStatusCode.OK) {
                return Json(new { success = true, user });

            }
            return Json(new { success = false, errors=responseObject.Error.Errors });
        }


        [HttpPost("/Admin/UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequestDTO updateUserRequestDTO)
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/User/", Method.Put);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);

            request.AddBody(updateUserRequestDTO,"application/json");

            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<object>>(apiResponse.Content);

            var result = responseObject.Data;


            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = result });
            }
            else
            {
                return Json(new { success = false, error = string.Join("<br />", responseObject.Error.Errors) });
            }

        }

        [HttpPost("/Admin/DeleteUser/{userGUID}")]
        public async Task<IActionResult> DeleteUser(Guid userGUID)
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/User/"+ userGUID, Method.Delete);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);

            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<bool>>(apiResponse.Content);

            var result = responseObject.Data;


            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error= string.Join("<br />", responseObject.Error.Errors) });
            }
           
        }


        [HttpPost("/Admin/AddUser")]
        public async Task<IActionResult> AddUser(AddUserRequestDTO addUserRequestDTO)
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/User/", Method.Post);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);

            request.AddBody(addUserRequestDTO, "application/json");

            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<UserDetailDTO>>(apiResponse.Content);

            var result = responseObject.Data;


            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error = string.Join("<br />", responseObject.Error.Errors) });
            }

        }
    }
}
