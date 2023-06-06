using System.ComponentModel.DataAnnotations;

namespace PracticalTest.BusinessObjects
{
    public class SportEvents
    {

        [Key]
        public int Id { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string EventName { get; set; }
        public string EventType { get; set; }
        public Organizers organizer { get; set; }
    }
}
