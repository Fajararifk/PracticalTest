using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO
{
    public class JsonSportEventsAll
    {
        public List<DataSportEvent> data { get; set; }
        public Meta meta { get; set; }
    }
    public class DataSportEvent
    {
        public string eventDate { get; set; }
        public string eventName { get; set; }
        public string eventType { get; set; }
        public int id { get; set; }
        public Organizers organizer { get; set; }
    }

    
}
