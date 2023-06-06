using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO;
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

        public async Task<IEnumerable<SportEvents>> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            var getAllSportEventsASync = await _loginToAPI.GetAllSportEventsAsync(page, perPage, organizerID);
            var get = getAllSportEventsASync["data"].ToJsonString();
            var result = JsonConvert.DeserializeObject<List<SportEvents>>(get);
            return result;
        }

        public async Task<SportEvents> GetSportEventsByIdAsync(int id)
        {
            var getSportEventsByIdAsync = await _loginToAPI.GetSportEventsByIdAsync(id);
            var get = getSportEventsByIdAsync.ToJsonString();
            var result = JsonConvert.DeserializeObject<SportEvents>(get);
            return result;
        }

        public void Insert(SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            var insert = _loginToAPI.InsertAsync(sportEventsCreateAPIDTO);
            var get = insert.ToString();
            var result = JsonConvert.DeserializeObject<SportEvents>(get);
            return;
        }

        public void Edit(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            _loginToAPI.EditAsync(id, sportEventsCreateAPIDTO);
        }

        public async void Delete(int id)
        {
            await _loginToAPI.DeleteAsync(id);
        }

    }
}
