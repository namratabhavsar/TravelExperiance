using System.ComponentModel.DataAnnotations;

namespace TravelExperianceManagement.Models.Domain
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required]
        public required string User { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }
        
        public DateTime CreatedAt { get; set;}

        //Navigation
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}
