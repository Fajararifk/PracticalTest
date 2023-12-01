using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL.Implement
{
    public class URLBase
    {
        private readonly IConfiguration _configuration;

        public URLBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string URLBaseAddress()
        {
            var urlConfig = _configuration.GetSection("MyAPIClient")["BaseAddress"];
            return urlConfig;
        }
    }
}
