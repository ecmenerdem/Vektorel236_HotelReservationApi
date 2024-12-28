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

        public async Task<ApiResult<IEnumerable<HotelDTO>>> GetAllHotelsAsync()
        {
            var hotels = await _uow.HotelRepository.GetAllAsync();

            if (!hotels.Any())
            {
                var error = new ErrorResult(new List<string> { "Hiç Otel Bulunamadı" });
                return ApiResult<IEnumerable<HotelDTO>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var hotelDTOList = _mapper.Map<IEnumerable<HotelDTO>>(hotels);

            return ApiResult<IEnumerable<HotelDTO>>.SuccesResult(hotelDTOList);

        }

        public async Task<ApiResult<HotelDTO>> GetHotelByGUIDAsync(Guid guid)
        {
            var hotel = await _uow.HotelRepository.GetAsync(q=>q.GUID==guid);

            if (hotel is null)
            {
                var error = new ErrorResult(new List<string> { "Otel Bulunamadı" });
                return ApiResult<HotelDTO>.FailureResult(error, HttpStatusCode.NotFound);
            }

            var hotelDTO = _mapper.Map<HotelDTO>(hotel);
            return ApiResult<HotelDTO>.SuccesResult(hotelDTO);
        }

        public async Task<ApiResult<bool>> UpdateHotel(HotelUpdateRequestDTO hotelUpdateRequestDTO)
        {
            await _validator.ValidateAsync(hotelUpdateRequestDTO,typeof(HotelUpdateValidator));

            var hotel = await _uow.HotelRepository.GetAsync(q => q.GUID == hotelUpdateRequestDTO.Guid);

            if (hotel is null) {
                throw new HotelNotFoundException();
            }

            _mapper.Map(hotelUpdateRequestDTO, hotel);
            await _uow.SaveChangeAsync();
            return ApiResult<bool>.SuccesResult(true);

        }
    }
}
