using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DTO
{
    public class UserToken : IdentityUserToken
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string LoginProvider { get; set; }
        public string UserId { get; set; }
    }

    public class IdentityUserToken
    {
    }
}
