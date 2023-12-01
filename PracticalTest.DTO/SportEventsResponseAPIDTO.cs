using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO
{
    public class SportEventsResponseAPIDTO
    {
        public int id { get; set; }
        public string eventDate { get; set; } = DateTime.Now.ToString("yyyy/dd/MM");
        public string eventType { get; set; }
        public string eventName { get; set; }
        public int organizerId { get; set; }
    }
}
