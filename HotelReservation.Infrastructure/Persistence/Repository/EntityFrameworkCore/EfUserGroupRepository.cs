namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore
{
    public class EfUserGroupRepository : EFRepository<UserGroup>,IUserGroupRepository
    {
        public EfUserGroupRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
