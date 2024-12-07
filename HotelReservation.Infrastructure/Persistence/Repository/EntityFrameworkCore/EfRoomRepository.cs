namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfRoomRepository : EFRepository<Room>,IRoomRepository
    {
        public EfRoomRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
