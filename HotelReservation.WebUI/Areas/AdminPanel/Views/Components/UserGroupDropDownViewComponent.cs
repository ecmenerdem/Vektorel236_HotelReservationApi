using HotelReservation.WebHelper.ApiHelper;
using HotelReservation.WebHelper.ApiHelper.Result;
using HotelReservation.WebHelper.DTO.UserGroup;
using HotelReservation.WebHelper.SessionHelper;
using HotelReservation.WebUI.Areas.AdminPanel.Models.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace HotelReservation.WebUI.Areas.AdminPanel.Views.Components
{
    public class UserGroupDropDownViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UserGroupDropDownViewModel model)
        {
           var modelData = new List<UserGroupDTO>();
            if (model.Data is null)
            {
                var client = new RestClient();
                var request = new RestRequest($"{ApiEndpoint.ApiEndpointURL}/UserGroups", Method.Get);

                request.AddHeader("Authorization", "Bearer " + SessionManager.Token);


                var apiResponse = await client.ExecuteAsync(request);

                var responseObject = JsonSerializer.Deserialize<ApiResult<List<UserGroupDTO>>>(apiResponse.Content);

                modelData = responseObject.Data;

            }

            else
            {
                modelData = model.Data;
            }

            UserGroupDropDownViewModel userGroupDropDownViewModel = new()
            {
                ElementID = model.ElementID,
                Data = modelData,
                SelectedItemGUID=model.SelectedItemGUID,
            };

            return View("~/Areas/AdminPanel/Views/Shared/Component/UserGroup/UserGroupDropDown.cshtml", userGroupDropDownViewModel);

        }
    }
}
