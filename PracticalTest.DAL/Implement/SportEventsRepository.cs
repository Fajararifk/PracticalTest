using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.Text.Json.Nodes;

namespace PracticalTest.DAL
{
    public class SportEventRepository : ISportEventsRepository
    {
        private readonly IMethodFromAPI _loginToAPI;
        private readonly IRepositoryCallAPI _repositoryCallAPI;
        const string UrlBase = "https://api-sport-events.php6-02.test.voxteneo.com/api/v1/";

        public SportEventRepository(IMethodFromAPI loginToAPI, IRepositoryCallAPI repositoryCallAPI)
        {
            _loginToAPI = loginToAPI;
            _repositoryCallAPI = repositoryCallAPI;
        }

        public async Task<JsonSportEventsAll> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            var url = $"{UrlBase}sport-events?page={page}&perPage={perPage}&organizerId={organizerID}";
            return await _repositoryCallAPI.Get<JsonSportEventsAll>(url);
            /*var getAllSportEventsASync = await _loginToAPI.GetAllSportEventsAsync(page, perPage, organizerID);
            var get = getAllSportEventsASync["data"].ToJsonString();
            var result = JsonConvert.DeserializeObject<List<SportEvents>>(get);
            return result;*/
        }

        public async Task<SportEvents> GetSportEventsByIdAsync(int id)
        {
            var url = $"{UrlBase}sport-events/{id}";
            return await _repositoryCallAPI.Get<SportEvents>(url);
            /*var getSportEventsByIdAsync = await _loginToAPI.GetSportEventsByIdAsync(id);
            var get = getSportEventsByIdAsync.ToJsonString();
            var result = JsonConvert.DeserializeObject<SportEvents>(get);
            return result;*/
        }

        public async Task<SportEventsResponseAPIDTO> Insert(SportEventsCreateAPIDTO sportEvents)
        {
            var url = $"{UrlBase}sport-events";
            var insert = await _repositoryCallAPI.Create<SportEventsResponseAPIDTO, SportEventsCreateAPIDTO>(url, sportEvents);
            return insert;
        }

        public async Task<SportEventsCreateAPIDTO> Edit(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            var url = $"{UrlBase}sport-events/{id}";
            return await _repositoryCallAPI.Update<SportEventsCreateAPIDTO, SportEventsCreateAPIDTO>(url, id, sportEventsCreateAPIDTO);
        }

        public async Task Delete(int id)
        {
            var url = $"{UrlBase}sport-events/{id}";
            await _repositoryCallAPI.Delete(url, id);
            //await _loginToAPI.DeleteSportEventAsync(id);
        }

    }
}
