using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO.Create
{
    public class SportEventsCreateAPIDTO
    {
        public DateTime eventDate { get; set; } = DateTime.Now;
        public string? eventType { get; set; }
        public string? eventName { get; set; }
        public virtual ICollection<Organizers>? organizerId { get; set; }
    }
}
