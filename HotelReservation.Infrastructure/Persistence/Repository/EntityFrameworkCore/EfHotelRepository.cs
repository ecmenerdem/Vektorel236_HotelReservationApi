using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Repository;
using HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
