using HotelReservation.Application.DTO.Hotel;
using HotelReservation.Application.DTO.Hotel.Add;
using HotelReservation.Application.DTO.Hotel.Update;
using HotelReservation.Application.Result;
using HotelReservation.Application.UseCases.AppHotel.Validation;
using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Exceptions.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.AppHotel
{
    public class HotelManager : IHotelService
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericValidator _validator;
        private readonly IMapper _mapper;

        public HotelManager(IUnitOfWork uow, IGenericValidator validator, IMapper mapper)
        {
            _uow = uow;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<ApiResult<HotelDTO>> AddHotelAsync(HotelAddRequestDTO hotelAddRequestDTO)
        {
            await _validator.ValidateAsync(hotelAddRequestDTO, typeof(HotelAddValidator));

            var hotel = _mapper.Map<Hotel>(hotelAddRequestDTO);

            await _uow.HotelRepository.AddAsync(hotel);
            await _uow.SaveChangeAsync();

            return ApiResult<HotelDTO>.SuccesResult(_mapper.Map<HotelDTO>(hotel), HttpStatusCode.OK, "Otel Başarılı Bir Şekilde Eklendi");

        }

        public async Task<ApiResult<bool>> DeleteHotel(Guid guid)
        {
            var hotel = await _uow.HotelRepository.GetAsync(q => q.GUID == guid);

            if (hotel == null) {

                throw new HotelNotFoundException();
            }

            hotel.IsDeleted = true;
            hotel.IsActive = false;

            _uow.HotelRepository.Update(hotel);
            await _uow.SaveChangeAsync();

            return ApiResult<bool>.SuccesResult(true,HttpStatusCode.OK,"Otel Silindi");
            
        }

        public Task<ApiResult<IEnumerable<HotelDTO>>> GetAllHotelsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<HotelDTO>> GetHotelByGUIDAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHotel(HotelUpdateRequestDTO hotelUpdateRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
