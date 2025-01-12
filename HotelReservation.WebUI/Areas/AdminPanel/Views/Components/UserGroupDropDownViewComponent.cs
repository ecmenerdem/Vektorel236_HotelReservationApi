using HotelReservation.WebHelper.ApiHelper;
using HotelReservation.WebHelper.ApiHelper.Result;
using HotelReservation.WebHelper.DTO.UserGroup;
using HotelReservation.WebHelper.SessionHelper;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace HotelReservation.WebUI.Areas.AdminPanel.Views.Components
{
    public class UserGroupDropDownViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new RestClient();
            var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/UserGroups", Method.Get);

            request.AddHeader("Authorization", "Bearer " + SessionManager.Token);


            var apiResponse = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<List<UserGroupDTO>>>(apiResponse.Content);

            return View("~/Areas/AdminPanel/Views/Shared/Component/UserGroup/UserGroupDropDown.cshtml", responseObject.Data);

        }
    }
}
