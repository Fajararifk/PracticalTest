using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using System.Text.Json;
using System.Text.Json.Nodes;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PracticalTest.DAL
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private ILoginToAPI _loginToAPI;

        public OrganizerRepository(ILoginToAPI loginToAPI)
        {
            _loginToAPI = loginToAPI;
        }

        public async Task<IEnumerable<Organizers>> GetAllOrganizerAsync(int page, int perPage)
        {
            var getAllOrganizerAsync = await _loginToAPI.GetAllOrganizerAsync(page, perPage);
            var get = getAllOrganizerAsync["data"].ToJsonString();
            var result = JsonConvert.DeserializeObject<List<Organizers>>(get);
            return result;
        }

        public async Task<Organizers> GetOrganizerByIdAsync(int id)
        {
            var getOrganizerByIdAsync = await _loginToAPI.GetOrganizerByIdAsync(id);
            var get = getOrganizerByIdAsync.ToJsonString();
            var result = JsonConvert.DeserializeObject<Organizers>(get);
            return result;
        }

        public void Insert(OrganizerCreateDTO organizer)
        {
            _loginToAPI.InsertAsync(organizer);
        }
        public void Edit(int id, OrganizerCreateDTO organizer)
        {
            _loginToAPI.EditAsync(id, organizer);
        }

        public void Delete(int id)
        {
           _loginToAPI.DeleteAsync(id);
        }

    }
}
