using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Repository.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Repository
{
    public interface IReservationRepository:IRepository<Reservation>
    {
       
    }
}
