using HotelReservation.WebHelper.DTO.Account;

namespace HotelReservation.WebUI.Areas.AdminPanel.Models.ViewModels.Login
{
    public class LoginViewModel
    {
        public string ExceptionMessage { get; set; }

        public WebLoginRequestDTO webLoginRequestDTO { get; set; }

    }
}
