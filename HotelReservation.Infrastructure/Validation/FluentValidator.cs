using FluentValidation;
using FluentValidation.Results;
using HotelReservation.Application.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Validation
{
    public class FluentValidator : IGenericValidator
    {
        public async Task ValidateAsync<T>(T entity, Type typeOfValidator = null)
        {
            if (!typeof(IValidator).IsAssignableFrom(typeOfValidator))
            {
                throw new Exception("Validator Tipi Geçersiz.");
            }

            var validator = Activator.CreateInstance(typeOfValidator) as IValidator;

            ValidationResult validationResult = await validator.ValidateAsync(new ValidationContext<T>(entity));

            if (!validationResult.IsValid) 
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
