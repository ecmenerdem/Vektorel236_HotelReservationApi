using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Repository;
using HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfRoomRepository : EFRepository<Room>,IRoomRepository
    {
        public EfRoomRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
