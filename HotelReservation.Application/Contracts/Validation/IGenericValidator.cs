namespace HotelReservation.Application.Contracts.Validation
{
    public interface IGenericValidator
    {
        Task ValidateAsync<T>(T entity, Type typeOfValidator = null);
    }
}
