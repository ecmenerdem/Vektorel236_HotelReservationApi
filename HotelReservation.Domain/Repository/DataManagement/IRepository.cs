using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Repository.DataManagement
{
    public interface IRepository<T>where T: AuditableEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] includeProperties);

        ValueTask AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
