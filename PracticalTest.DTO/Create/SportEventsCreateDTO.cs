using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO.Create
{
    public class SportEventsCreateDTO
    {
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string EventName { get; set; }
        public string EventType { get; set; }
        public IEnumerable<Organizers> Organizers { get; set; }
    }
}
