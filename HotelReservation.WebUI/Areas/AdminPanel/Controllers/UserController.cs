﻿using HotelReservation.WebHelper.ApiHelper.Result;
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
            var request = new RestRequest("http://localhost:5211/Users", Method.Get);

            request.AddHeader("Authorization","Bearer "+SessionManager.Token);


            var apiResponse = await client.ExecuteAsync(request);

                var responseObject = JsonSerializer.Deserialize<ApiResult<List<UserDetailDTO>>>(apiResponse.Content);

            return View(responseObject.Data);
           
        }

        [HttpGet("/Admin/User/{guid}")]
        public async Task<IActionResult> GetUserDetail(Guid guid)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5211/User/"+guid, Method.Get);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);


            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<UserDetailDTO>>(apiResponse.Content);

            var user = responseObject.Data;

            return Json(new { success = true, user });
        }
        

    }
}
