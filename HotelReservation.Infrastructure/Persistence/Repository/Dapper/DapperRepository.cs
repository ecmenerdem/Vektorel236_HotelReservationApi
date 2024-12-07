namespace HotelReservation.Infrastructure.Persistence.Repository.Dapper
{
    public class DapperRepository<T> : IRepository<T> where T : AuditableEntity
    {
        public ValueTask AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
