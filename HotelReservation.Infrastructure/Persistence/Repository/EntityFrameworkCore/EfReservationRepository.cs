namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfReservationRepository : EFRepository<Reservation>,IReservationRepository
    {
        public EfReservationRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
