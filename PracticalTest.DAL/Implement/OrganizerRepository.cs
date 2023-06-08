using AutoMapper;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DAL.Implement;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Text.Json.Nodes;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PracticalTest.DAL
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private IMethodFromAPI _loginToAPI;
        private readonly IMapper _mapper;
        private readonly IRepositoryCallAPI _repositoryCallAPI;
        const string UrlBase = "https://api-sport-events.php6-02.test.voxteneo.com/api/v1/";

        public OrganizerRepository(IMethodFromAPI loginToAPI, IRepositoryCallAPI callAPI, IMapper mapper)
        {
            _loginToAPI = loginToAPI;
            _repositoryCallAPI = callAPI;
            _mapper = mapper;
        }

        public async Task<JsonOrganizer> GetAllOrganizerAsync(int page, int perPage)
        {
            var url = $"{UrlBase}organizers?page={page}&perPage={perPage}";
            return await _repositoryCallAPI.Get<JsonOrganizer>(url);
            /*var getAllOrganizerAsync = await _loginToAPI.GetAllOrganizerAsync(page, perPage);
            var get = getAllOrganizerAsync["data"].ToJsonString();
            var result = JsonConvert.DeserializeObject<List<Organizers>>(get);
            return result;*/
        }

        public async Task<Organizers> GetOrganizerByIdAsync(int id)
        {
            
            var url = $"{UrlBase}organizers/{id}";
            return await _repositoryCallAPI.Get<Organizers>(url);
           /* var getOrganizerByIdAsync = await _loginToAPI.GetOrganizerByIdAsync(id);
            var get = getOrganizerByIdAsync.ToJsonString();
            var result = JsonConvert.DeserializeObject<Organizers>(get);
            return result;*/
        }

        public async Task<Organizers> Insert(OrganizerCreateDTO organizer)
        {
            var url = $"{UrlBase}organizers";
            var organizers = await _repositoryCallAPI.Create<Organizers, OrganizerCreateDTO>(url, organizer);
            return organizers;
            //_loginToAPI.InsertAsync(organizer);
        }
        public async Task<OrganizerCreateDTO> Edit(int id, OrganizerCreateDTO organizer)
        {
            var url = $"{UrlBase}organizers/{id}";
            return await _repositoryCallAPI.Update<OrganizerCreateDTO, OrganizerCreateDTO>(url, id,organizer);
            //_loginToAPI.EditAsync(id, organizer);
        }

        public async Task Delete(int id)
        {
            var url = $"{UrlBase}organizers/{id}";
            await _repositoryCallAPI.Delete(url,id);
            //_loginToAPI.DeleteAsync(id);
        }

    }
}
