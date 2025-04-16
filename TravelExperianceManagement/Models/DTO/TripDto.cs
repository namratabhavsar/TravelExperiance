using System.ComponentModel.DataAnnotations;

namespace TravelExperianceManagement.Models.DTO
{
    public class TripDto
    {
       
        public string? User { get; set; }

        public required string Title { get; set; }
     
        public DateOnly StartDate { get; set; }
      
        public string? Description { get; set; }

        public DateOnly EndDate { get; set; }
       
    }
}
