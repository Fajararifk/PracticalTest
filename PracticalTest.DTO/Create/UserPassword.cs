using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO.Create
{
    public class UserPassword
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string repeatPassword { get; set; }
    }
}
