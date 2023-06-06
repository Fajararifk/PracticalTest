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
        public Meta Meta { get; set; }
        public List<SportEvents> Data { get; set; }
    }
    public class Meta
    {
        public Pagination Pagination { get; set; }
    }
    public class Pagination
    {
        public int total { get; set; }
        public int count { get; set; }
        public int per_page { get; set; }
        public int total_pages { get; set; }
        public List<Links> links { get; set; }
    }
    public class Links
    {
        public string next { get; set; }
    }
}
