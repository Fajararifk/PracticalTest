using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface ISportEventsBLL
    {
        Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        Task<JsonNode> GetSportEventsAsync(int Id);
        Task<JsonNode> InsertAsync(SportEventsCreateAPIDTO organizerCreateDTO);
        Task<JsonNode> EditAsync(int id, SportEventsCreateAPIDTO organizerCreateDTO);
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
