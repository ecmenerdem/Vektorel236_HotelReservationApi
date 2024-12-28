using HotelReservation.Application.DTO.Hotel;
using HotelReservation.Application.DTO.Hotel.Add;
using HotelReservation.Application.DTO.Hotel.Update;
using HotelReservation.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Contracts.Persistence
{
    public interface IHotelService
    {
        Task<ApiResult<HotelDTO>> GetHotelByGUIDAsync(Guid guid);
        Task<ApiResult<IEnumerable<HotelDTO>>> GetAllHotelsAsync();
        Task<ApiResult<bool>> UpdateHotel(HotelUpdateRequestDTO hotelUpdateRequestDTO);

        Task<ApiResult<bool>> DeleteHotel(Guid guid);
        Task<ApiResult<HotelDTO>> AddHotelAsync(HotelAddRequestDTO hotelAddRequestDTO);
    }
}
