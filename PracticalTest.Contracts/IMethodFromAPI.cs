using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IMethodFromAPI
    {
        // Tidak terpakai
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
