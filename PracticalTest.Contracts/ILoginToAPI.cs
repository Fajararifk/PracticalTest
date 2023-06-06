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
        public Task<JsonNode> GetAllOrganizerAsync(int page, int perPage);
        public Task<JsonNode> GetOrganizerByIdAsync(int id);
        public Task<JsonNode> EditAsync(int id, OrganizerCreateDTO organizer);
        public Task<JsonNode> InsertAsync(OrganizerCreateDTO organizer);
        public Task<HttpResponseMessage> DeleteAsync(int id);
        public Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        public Task<JsonNode> GetSportEventsByIdAsync(int id);
        public Task<JsonNode> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        public Task<JsonNode> EditAsync(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        public Task<HttpResponseMessage> DeleteSportEventAsync(int id);
    }
}
