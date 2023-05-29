using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BusinessObjects
{
    public class SportEvents
    {

        [Key]
        public int Id { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string EventName { get; set; }
        public string EventType { get; set; }
        public IEnumerable<Organizers> Organizers { get; set; }
    }
}
