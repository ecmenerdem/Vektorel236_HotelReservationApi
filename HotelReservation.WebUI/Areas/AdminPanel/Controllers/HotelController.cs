﻿using HotelReservation.WebHelper.ApiHelper;
using HotelReservation.WebHelper.ApiHelper.Result;
using HotelReservation.WebHelper.DTO.Hotel;
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

    public class HotelController : Controller
    {
       
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment=webHostEnvironment;
        }

        [HttpGet("/Admin/Oteller")]
        public async Task<IActionResult> Index()
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/Hotels", Method.Get);

            request.AddHeader("Authorization", "Bearer "+SessionManager.Token);


            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<List<HotelDetailDTO>>>(apiResponse.Content);

            if (responseObject.Data != null) {
                return View(responseObject.Data);
            }

            return View(Enumerable.Empty<HotelDetailDTO>().ToList());
        }

        [HttpPost("Admin/AddHotel")]
        public async Task<IActionResult> AddHotel(AddHotelRequestDTO addHotelRequestDTO, IFormFile hotelImage)
        {

            string fileName = hotelImage.FileName.Split('.')[hotelImage.FileName.Split('.').Length-2]+"_"+Guid.NewGuid()+"."+hotelImage.FileName.Split('.')[hotelImage.FileName.Split('.').Length-1];

            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "MediaUpload", fileName);

            using (var fileStream = new FileStream(uploadFolder,FileMode.Create))
            {
                hotelImage.CopyTo(fileStream);
            }

            addHotelRequestDTO.FeaturedImage=fileName;

            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/Hotel/", Method.Post);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);

            request.AddBody(addHotelRequestDTO, "application/json");

            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<HotelDetailDTO>>(apiResponse.Content);

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
