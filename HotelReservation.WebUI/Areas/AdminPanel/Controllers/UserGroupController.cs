using HotelReservation.WebUI.Areas.AdminPanel.Models.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserGroupController : Controller
    {
        [HttpGet("/InvokeUserGroupDropDown")]
        public IActionResult InvokeUserGroupDropDown(string elementID, Guid selectedItemGUID)
        {
            UserGroupDropDownViewModel model = new UserGroupDropDownViewModel()
            {
                ElementID = elementID,
                SelectedItemGUID = selectedItemGUID
            };
            return ViewComponent("UserGroupDropDown", model);
        }
    }
}
