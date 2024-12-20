﻿using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Repository.DataManagement;
using System.Linq.Expressions;

namespace HotelReservation.Domain.Repository
{
    public interface IUserRepository:IRepository<User>
    {
       Task<User> LoginAsync(User user);
        Task<IEnumerable<User>> GetDeletedUsers();

    }
}
