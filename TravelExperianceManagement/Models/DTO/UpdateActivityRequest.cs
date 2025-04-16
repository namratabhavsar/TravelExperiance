namespace TravelExperianceManagement.Models.DTO
{
    public class UpdateActivityRequest
    {
        public required string ActivityName { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
        public int DestinationId { get; set; }
    }
}
