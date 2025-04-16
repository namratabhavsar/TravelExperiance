using System.ComponentModel.DataAnnotations;
using TravelExperianceManagement.Models.Domain;

namespace TravelExperianceManagement.Models.DTO
{
    public class ActivityDto
    {
        [MaxLength(100)]
        [Required]
        public required string ActivityName { get; set; }

        public int Duration { get; set; }

        [Required]
        public double Cost { get; set; }

        //Navigations
        public Trip Trip { get; set; }
        public Destination Destination { get; set; }
    }
}
