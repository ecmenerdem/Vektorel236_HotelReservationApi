using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Repository.DataManagement
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IHotelRepository HotelRepository { get; }
        IRoomRepository RoomRepository { get; } 
        IReservationRepository ReservationRepository { get; }

        Task<int> SaveChangeAsync();
    }
}
