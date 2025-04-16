using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TravelExperianceManagement.Models.DTO
{
    public class UpdateTripRequest
    {
        public required string User { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly StartDate { get; set; } 
        public DateOnly EndDate { get; set;}

    }
}
