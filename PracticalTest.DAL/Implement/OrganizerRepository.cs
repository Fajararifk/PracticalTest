using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using NLog.Fluent;
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
    public class OrganizerRepository : IOrganizerRepository
    {
        private ILoginToAPI _loginToAPI;

        public OrganizerRepository(ILoginToAPI loginToAPI)
        {
            _loginToAPI = loginToAPI;
        }
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var deleteAsync = await _loginToAPI.DeleteAsync(id);
            return deleteAsync;
        }

        public async Task<JsonNode> EditAsync(int id, OrganizerCreateDTO organizer)
        {
            var editAsync = await _loginToAPI.EditAsync(id, organizer);
            return editAsync;
        }

        public async Task<JsonNode> GetAllOrganizerAsync(int page, int perPage)
        {
            var getAllOrganizerAsync = await _loginToAPI.GetAllOrganizerAsync(page, perPage);
            return getAllOrganizerAsync;
        }

        public async Task<JsonNode> GetOrganizerByIdAsync(int id)
        {
            var getOrganizerByIdAsync = await _loginToAPI.GetOrganizerByIdAsync(id);
            return getOrganizerByIdAsync;
        }

        public async Task<JsonNode> InsertAsync(OrganizerCreateDTO organizer)
        {
            var insertAsync = await _loginToAPI.InsertAsync(organizer);
            return insertAsync;
        }

    }
}
