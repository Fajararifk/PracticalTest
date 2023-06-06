using PracticalTest.BusinessObjects;

namespace PracticalTest.DTO
{
    public class SportEventsDTO
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string EventName { get; set; }
        public string EventType { get; set; }
        public Organizers organizer { get; set; }
    }
}
