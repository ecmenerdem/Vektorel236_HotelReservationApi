using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Repository;
using HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfReservationRepository : EFRepository<Reservation>,IReservationRepository
    {
        public EfReservationRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
