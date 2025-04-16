namespace TravelExperianceManagement.Models.DTO
{
    public class CreateTripRequest
    {
        public required string User { get; set; } 
        public required string Title { get; set; } 
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<CreateActivityRequest> Activities { get; set; } = new List<CreateActivityRequest>();
    }
}
