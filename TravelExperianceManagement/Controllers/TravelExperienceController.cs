using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExperianceManagement.Data;
using TravelExperianceManagement.Models.Domain;
using TravelExperianceManagement.Models.DTO;
using TravelExperianceManagement.Repositories;
using TravelExperianceManagement.Repositories.Interfaces;

namespace TravelExperianceManagement.Controllers
{

    //https://localhost:7043/api/Trips
    [Route("api/[controller]")]
    [ApiController]
    public class TravelExperienceController : ControllerBase
    {

        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TravelExperienceController> _logger;
        public TravelExperienceController(ITripRepository tripRepository,IMapper mapper, 
            ILogger<TravelExperienceController> logger)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _logger = logger;
            
        }

        //GET all trips
        //GET: https://localhost:portnumber/api/Trips
        [HttpGet]
        public  async Task<IActionResult> GetAllTrips()
        {
            try
            {
                var tripsDomain = await _tripRepository.GetAllTripsAsync();

                //map domain models to dto
                var tripDto = _mapper.Map<List<TripDto>>(tripsDomain);

                return Ok(tripDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving trip");
                return StatusCode(500, "Internal server error.");
            }
        }

        //GET trip by Id
        //GET : https://localhost:portnumber/api/Trips/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTripById([FromRoute] int id)
        {
            var trip = await _tripRepository.GetTripByIdAsync(id);

            if (trip == null)
                return NotFound();
            //map domain model to dto
            var tripDto = _mapper.Map<TripDto>(trip);
            
            return Ok(tripDto);
        }

        //POST all trips
        //POST: https://localhost:portnumber/api/Trips
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] CreateTripRequest tripRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (tripRequest.StartDate > tripRequest.EndDate)
            {
                _logger.LogWarning("StartDate {StartDate} is after EndDate {EndDate}", tripRequest.StartDate, tripRequest.EndDate);
                return BadRequest("Start date cannot be after end date.");
            }

            //convert DTO to Domain model
            var tripDomainModel = _mapper.Map<Trip>(tripRequest);
           
            //use domain model to create trip
            var trip = await _tripRepository.CreateTripAsync(tripDomainModel);
            
            //map domain model back to DTO
            var tripDto = _mapper.Map<TripResponse>(trip);

            //return 201 : created record in DB
            return CreatedAtAction(nameof(CreateTrip), new { id = tripDto.TripId }, tripDto);

        }

        //Update trip 
        //PUT : https://localhost:portnumber/api/Trips/{id}
        [HttpPut]
        [Route("{id:int}")]
        public  async Task<IActionResult> UpdateTrip([FromRoute] int id, [FromBody] UpdateTripRequest updateTripRequest)
        {
            //map dto to domain model
            var trip = _mapper.Map<Trip>(updateTripRequest);
        
            var tripDomainModel = await _tripRepository.UpdateTripAsync(id , trip);
            if (tripDomainModel == null)
            {
                return NotFound();
            }

            //domain model to dto
            var tripDto = _mapper.Map<TripDto>(tripDomainModel);
         
            return Ok(tripDto);
        }

        //Delete
        //DELETE: https://localhost:portnumber/api/Trips/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTrip([FromRoute] int id)
        {
            var tripDomainModel = await _tripRepository.DeleteTripAsync(id);
            if(tripDomainModel == null)
            {
                return NotFound();
            }

            //return deleted trip back
            //map domain model to dto
            var tripDto = _mapper.Map<TripDto>(tripDomainModel);
            return Ok(tripDto);
        }
    }
}
