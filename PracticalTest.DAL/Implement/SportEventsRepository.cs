using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DAL.Implement;
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
        private readonly URLBase _url;
        const string SportEvents = "sport-events";

        public SportEventRepository(IMethodFromAPI loginToAPI, IRepositoryCallAPI repositoryCallAPI, URLBase url)
        {
            _loginToAPI = loginToAPI;
            _repositoryCallAPI = repositoryCallAPI;
            _url = url;
        }

        public async Task<JsonSportEventsAll> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            var url = $"{_url.URLBaseAddress()}{SportEvents}?page={page}&perPage={perPage}&organizerId={organizerID}";
            return await _repositoryCallAPI.Get<JsonSportEventsAll>(url);
        }

        public async Task<SportEvents> GetSportEventsByIdAsync(int id)
        {
            var url = $"{_url.URLBaseAddress()}{SportEvents}/{id}";
            return await _repositoryCallAPI.Get<SportEvents>(url);
        }

        public async Task<SportEventsResponseAPIDTO> InsertAsync(SportEventsCreateAPIDTO sportEvents)
        {
            var url = $"{_url.URLBaseAddress()}{SportEvents}";
            var insert = await _repositoryCallAPI.Create<SportEventsResponseAPIDTO, SportEventsCreateAPIDTO>(url, sportEvents);
            return insert;
        }

        public async Task<SportEventsCreateAPIDTO> EditAsync(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            var url = $"{_url.URLBaseAddress()}{SportEvents}/{id}";
            return await _repositoryCallAPI.Update<SportEventsCreateAPIDTO, SportEventsCreateAPIDTO>(url, id, sportEventsCreateAPIDTO);
        }

        public async Task DeleteAsync(int id)
        {
            var url = $"{_url.URLBaseAddress()}{SportEvents}/{id}";
            await _repositoryCallAPI.Delete(url, id);
        }

    }
}
