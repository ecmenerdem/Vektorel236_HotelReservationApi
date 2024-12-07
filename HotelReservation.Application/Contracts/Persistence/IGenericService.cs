namespace HotelReservation.Application.Contracts.Persistence
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);

        Task<T> AddAsync(T entity);
    }
}
