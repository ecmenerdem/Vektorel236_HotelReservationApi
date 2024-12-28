using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.DTO.Hotel;
using HotelReservation.Application.DTO.Hotel.Add;
using HotelReservation.Application.DTO.Hotel.Update;
using HotelReservation.Application.DTO.User;
using HotelReservation.Application.Result;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [ApiController]
    [Route("HotelReservationApi/[action]")]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("/Hotel/{guid}")]
        [ProducesResponseType(typeof(ApiResult<HotelDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHotelByGUID(Guid guid)
        {
            var result = await _hotelService.GetHotelByGUIDAsync(guid);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("/Hotels")]
        [ProducesResponseType(typeof(ApiResult<List<HotelDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllHotelsAsync()
        {
            var result = await _hotelService.GetAllHotelsAsync();
            return StatusCode((int)result.StatusCode, result);
        }
        
        [HttpPost("/Hotel")]
        [ProducesResponseType(typeof(ApiResult<HotelDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddHotelAsync([FromBody]HotelAddRequestDTO hotelAddRequestDTO)
        {
            var result = await _hotelService.AddHotelAsync(hotelAddRequestDTO);
            return StatusCode((int)result.StatusCode, result);
        }
        
        [HttpPut("/Hotel")]
        [ProducesResponseType(typeof(ApiResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelUpdateRequestDTO hotelUpdateRequestDTO)
        {
            var result = await _hotelService.UpdateHotel(hotelUpdateRequestDTO);
            return StatusCode((int)result.StatusCode, result);
        }

    }
}
