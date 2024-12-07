namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfUserRepository : EFRepository<User>,IUserRepository
    {
        private readonly DbContext _dbContext;
        public EfUserRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> LoginAsync(User user)
        {
            return await _dbContext.Set<User>().SingleOrDefaultAsync(q => q.Username == user.Username && q.Password == user.Password);
        }
    }
}
