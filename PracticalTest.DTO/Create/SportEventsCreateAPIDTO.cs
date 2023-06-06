namespace PracticalTest.DTO.Create
{
    public class SportEventsCreateAPIDTO
    {
        public DateTime eventDate { get; set; } = DateTime.Now;
        public string? eventType { get; set; }
        public string? eventName { get; set; }
        public int? organizerId { get; set; }
    }
}
