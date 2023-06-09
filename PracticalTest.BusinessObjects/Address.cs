using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BusinessObjects
{
    public class Address
    {
        [Key]

        public int AdId { get; set; }
        public string AdStreetFr { get; set; }
        public string AdBuilding { get; set; }
        public int? AdPostalCode { get; set; }
        public string AdCity { get; set; }
        public string AdUrbisRef { get; set; }
        public bool? AdIsUrbirsAddress { get; set; }
        public string AdStreetNl { get; set; }
        public string AdStreetEn { get; set; }
        public virtual ICollection<SportEvents> SportEvents { get; set; }
    }

}
