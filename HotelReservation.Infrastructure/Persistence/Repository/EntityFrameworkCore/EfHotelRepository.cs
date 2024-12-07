namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfHotelRepository : EFRepository<Hotel>,IHotelRepository
    {
        private readonly DbContext _dbContext;
        public EfHotelRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hotel> GetHotelByRoomId(int RoomID)
        {
          return await _dbContext.Set<Hotel>().Include(q => q.Rooms).SingleOrDefaultAsync(x => x.ID == RoomID);
        }
    }
}
