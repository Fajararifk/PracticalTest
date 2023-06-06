using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace PracticalTest.DAL
{
    public class SportEventRepository : ISportEventsRepository
    {
        private readonly ILoginToAPI _loginToAPI;

        public SportEventRepository(ILoginToAPI loginToAPI)
        {
            _loginToAPI = loginToAPI;
        }

        public async Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            var getAllSportEventsASync = await _loginToAPI.GetAllSportEventsAsync(page, perPage, organizerID);
            return getAllSportEventsASync;
        }

        public async Task<JsonNode> GetSportEventsByIdAsync(int id)
        {
            var getSportEventsByIdAsync = await _loginToAPI.GetSportEventsByIdAsync(id);
            return getSportEventsByIdAsync;
        }

        public async Task<JsonNode> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            var insertAsync = await _loginToAPI.InsertAsync(sportEventsCreateAPIDTO);
            return insertAsync;
        }

        public async Task<JsonNode> EditAsync(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            var editAsync = await _loginToAPI.EditAsync(id, sportEventsCreateAPIDTO);
            return editAsync;
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var deleteAsync = await _loginToAPI.DeleteAsync(id);
            return deleteAsync;
        }
    }
}
