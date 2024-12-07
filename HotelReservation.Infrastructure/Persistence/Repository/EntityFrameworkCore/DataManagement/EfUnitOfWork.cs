namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public EfUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new EfUserRepository(_dbContext);
            HotelRepository = new EfHotelRepository(_dbContext);
            RoomRepository = new EfRoomRepository(_dbContext);
            ReservationRepository = new EfReservationRepository(_dbContext);

           
        }

        public IUserRepository UserRepository { get; }

        public IHotelRepository HotelRepository { get; }

        public IRoomRepository RoomRepository { get; }

        public IReservationRepository ReservationRepository { get; }

        

        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in _dbContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State==EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.AddedIP = "192.168.2.1";
                    item.Entity.AddedUser = 1;

                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedIP = "192.168.2.1";
                    item.Entity.UpdatedUser = 1;
                }

                if (item.State == EntityState.Modified)
                {

                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedIP = "192.168.2.1";
                    item.Entity.UpdatedUser = 1;
                }
            }

            return await _dbContext.SaveChangesAsync();
        }
    }
}
