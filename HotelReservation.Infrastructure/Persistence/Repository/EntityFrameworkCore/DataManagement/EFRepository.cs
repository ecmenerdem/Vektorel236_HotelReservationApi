namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement
{
    public class EFRepository<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async ValueTask AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);

        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {

            IQueryable<T> query = _dbSet.AsNoTracking();

            if (filter is not null)
            {
                query.Where(filter);
            }

            foreach (var property in includeProperties)
            {

                query = query.Include(property);
            }

            return await Task.FromResult(query);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var property in includeProperties) {

                query=query.Include(property);
            }

            return await query.SingleOrDefaultAsync(filter);

        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);

        }
    }
}
