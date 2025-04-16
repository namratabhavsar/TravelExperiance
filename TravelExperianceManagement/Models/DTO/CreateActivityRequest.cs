namespace TravelExperianceManagement.Models.DTO
{
    public class CreateActivityRequest
    {
        public required string ActivityName { get; set; }
        public int DestinationId { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
    }
}
