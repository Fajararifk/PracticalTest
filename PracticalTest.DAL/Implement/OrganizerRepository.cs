using AutoMapper;
using Microsoft.Extensions.Configuration;
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
        private readonly URLBase _urlBase;
        const string Organizers = "organizers";
        const string UrlBase = "https://api-sport-events.php6-02.test.voxteneo.com/api/v1/";

        public OrganizerRepository(IMethodFromAPI loginToAPI, IRepositoryCallAPI callAPI, IMapper mapper, URLBase urlBase)
        {
            _loginToAPI = loginToAPI;
            _repositoryCallAPI = callAPI;
            _mapper = mapper;
            _urlBase = urlBase;
        }

        public async Task<JsonOrganizer> GetAllOrganizerAsync(int page, int perPage)
        {
            var url = $"{_urlBase.URLBaseAddress()}{Organizers}?page={page}&perPage={perPage}";
            return await _repositoryCallAPI.Get<JsonOrganizer>(url);
        }

        public async Task<Organizers> GetOrganizerByIdAsync(int id)
        {
            
            var url = $"{_urlBase.URLBaseAddress()}{Organizers}/{id}";
            var get = await _repositoryCallAPI
                .Get<Organizers>(url);
            return get;
        }

        public async Task<Organizers> InsertAsync(OrganizerCreateDTO organizer)
        {
            var url = $"{_urlBase.URLBaseAddress()}{Organizers}";
            var organizers = await _repositoryCallAPI
                .Create<Organizers, OrganizerCreateDTO>(url, organizer);
            return organizers;
        }
        public async Task<OrganizerCreateDTO> EditAsync(int id, OrganizerCreateDTO organizer)
        {
            var url = $"{_urlBase.URLBaseAddress()}{Organizers}/{id}";
            var edit = await _repositoryCallAPI
                .Update<OrganizerCreateDTO, OrganizerCreateDTO>(url, id,organizer);
            return edit;
        }

        public async Task DeleteAsync(int id)
        {
            var url = $"{_urlBase.URLBaseAddress()}{Organizers}/{id}";
            await _repositoryCallAPI.Delete(url,id);
        }

    }
}
