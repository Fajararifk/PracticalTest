using PracticalTest.BusinessObjects;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface ISportEventsRepository
    {
        Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        Task<JsonNode> GetSportEventsByIdAsync(int id);
        Task<JsonNode> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        Task<JsonNode> EditAsync(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
