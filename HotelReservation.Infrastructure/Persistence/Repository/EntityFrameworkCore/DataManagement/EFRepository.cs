using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Entity.Base;
using HotelReservation.Domain.Repository.DataManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement
{
    public class EFRepository<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(DbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
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
