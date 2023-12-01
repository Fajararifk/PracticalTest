using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO
{
    public class UserLoginResponse
    {
        public int id {  get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }
}
