using PracticalTest.BusinessObjects;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface ILoginToAPI
    {
        public Task<string> LoginAPI();
        public void TokenToDatabase(string token);
    }
}
