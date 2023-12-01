using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO
{
    public class JsonOrganizer
    {
        public List<Data> data { get; set; }
        public Meta meta { get; set; }
        
    }
    public class Data
    {
        public int id { get; set; }
        public string organizerName { get; set; }
        public string imageLocation { get; set; }
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
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public Links links { get; set; }
    }
    public class Links
    {
        public string next { get; set; }
    }
}
