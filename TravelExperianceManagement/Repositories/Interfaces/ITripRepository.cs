using TravelExperianceManagement.Models.Domain;

namespace TravelExperianceManagement.Repositories.Interfaces
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAllTripsAsync();

        Task<Trip?> GetTripByIdAsync(int id);

        Task<Trip?> CreateTripAsync(Trip trip);

        Task<Trip?> UpdateTripAsync(int id,Trip trip);
        Task<Trip?> DeleteTripAsync(int id);
    }
}
