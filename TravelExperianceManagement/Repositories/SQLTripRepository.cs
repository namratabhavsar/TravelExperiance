using Microsoft.EntityFrameworkCore;
using TravelExperianceManagement.Data;
using TravelExperianceManagement.Models.Domain;
using TravelExperianceManagement.Repositories.Interfaces;

namespace TravelExperianceManagement.Repositories
{
    public class SQLTripRepository : ITripRepository
    {
        private readonly TravelExperienceDbContext _travelDbContext;

        private readonly ILogger<SQLTripRepository> _logger;
        public SQLTripRepository(TravelExperienceDbContext travelDbContext, ILogger<SQLTripRepository> logger)
        {
            _travelDbContext = travelDbContext;
            _logger = logger;
        }

        public async Task<Trip?> CreateTripAsync(Trip trip)
        {
            try
            {
                await _travelDbContext.Trips.AddAsync(trip);
                await _travelDbContext.SaveChangesAsync();
                return trip;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error creating trip");
                return null;
            }
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            try
            {
                return await _travelDbContext.Trips.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all trips");
                return new List<Trip>();
            }
            
        }

        public async Task<Trip?> GetTripByIdAsync(int id)
        {
            try
            {
                return await _travelDbContext.Trips.FirstOrDefaultAsync(a => a.TripId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving trip with Id =  {id}");
                throw;
            }
        }

        public async Task<Trip?> UpdateTripAsync(int id,Trip trip)
        {
            try
            {
                var tripExists = await _travelDbContext.Trips.FirstOrDefaultAsync(a => a.TripId == id);
                if (tripExists == null)
                {
                    return null;
                }
                tripExists.User = trip.User;
                tripExists.Title = trip.Title;
                tripExists.Description = trip.Description;
                tripExists.Activities = trip.Activities;
                tripExists.StartDate = trip.StartDate;
                tripExists.EndDate = trip.EndDate;
                await _travelDbContext.SaveChangesAsync();
                return tripExists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving trip with Id =  {id}");
                return null;
            }
        }

        public async Task<Trip?> DeleteTripAsync(int id)
        {
            try
            {
                var existingTrip = await _travelDbContext.Trips.FirstOrDefaultAsync(a => a.TripId == id);
                if (existingTrip == null)
                {
                    return null;
                }
                _travelDbContext.Trips.Remove(existingTrip);
                await _travelDbContext.SaveChangesAsync();
                return existingTrip;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving trip with Id =  {id}");
                return null;
            }
        }
    }
}
