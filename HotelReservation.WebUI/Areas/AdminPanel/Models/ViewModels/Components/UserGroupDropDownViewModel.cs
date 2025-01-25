using HotelReservation.WebHelper.DTO.UserGroup;

namespace HotelReservation.WebUI.Areas.AdminPanel.Models.ViewModels.Components
{
    public class UserGroupDropDownViewModel
    {
        public string ElementID { get; set; }
        public List<UserGroupDTO> Data { get; set; }

        public Guid? SelectedItemGUID { get; set; }
    }
}
