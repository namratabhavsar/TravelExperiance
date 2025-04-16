using System.ComponentModel.DataAnnotations;

namespace TravelExperianceManagement.Models.Domain
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string DestinationName { get; set; }
       
    }
}
