namespace TravelExperianceManagement.Models.DTO
{
    public class TripResponse
    {
        public int TripId { get; set; }
        public required string User { get; set; }
        public required string Title { get; set; } 
        public double TotalCost { get; set; }
    }
}
