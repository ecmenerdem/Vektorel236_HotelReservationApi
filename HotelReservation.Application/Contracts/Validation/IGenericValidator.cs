using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Contracts.Validation
{
    public interface IGenericValidator
    {
        Task ValidateAsync<T>(T entity, Type typeOfValidator = null);
    }
}
