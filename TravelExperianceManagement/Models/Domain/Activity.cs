using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace TravelExperianceManagement.Models.Domain
{
    public class Activity
    {
   
        [Key]
        public int ActivityId { get; set; }

        [MaxLength(100)]
        [Required]
        public required string ActivityName { get; set; }

        public int Duration { get; set; }

        [Required]
        public double Cost { get; set; }

        public DateTime CreatedAt { get; set; }

        //foriegn keys
        public int TripId { get; set; }

        public int DestinationId { get; set; }

        //Navigations
        [ForeignKey("TripId")]
        public Trip Trip { get; set; }

        [ForeignKey("DestinationId")]
        public Destination Destination { get; set; }

    }
}
