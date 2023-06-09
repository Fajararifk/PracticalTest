using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL.Implement
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IRepositoryCallAPI _repositoryCallAPI;
        const string UrlBase = "https://api-sport-events.php6-02.test.voxteneo.com/api/v1/";
        private readonly URLBase _url;
        const string Users = "users";

        public UsersRepository(IRepositoryCallAPI callAPI, URLBase url_)
        {
            _repositoryCallAPI = callAPI;
            _url = url_;
        }

        public async Task<JsonOrganizer> GetAllUsersAsync(int page, int perPage)
        {
            var url = $"{_url.URLBaseAddress()}{Users}?page={page}&perPage={perPage}";
            return await _repositoryCallAPI.Get<JsonOrganizer>(url);
        }

        public async Task<UserResponseDTO> GetUsersByIdAsync(int id)
        {

            var url = $"{_url.URLBaseAddress()}{Users}/{id}";
            return await _repositoryCallAPI.Get<UserResponseDTO>(url);
        }

        public async Task<UserResponseDTO> InsertAsync(UserCreateAPIDTO organizer)
        {
            var url = $"{_url.URLBaseAddress()}{Users}";
            var insert = await _repositoryCallAPI.Create<UserResponseDTO, UserCreateAPIDTO>(url, organizer);
            return insert;
        }
        public async Task<UserLoginResponse> LoginAsync(UserLogin organizer)
        {
            var url = $"{_url.URLBaseAddress()}{Users}/login";
            var login = await _repositoryCallAPI.Create<UserLoginResponse, UserLogin>(url, organizer);
            return login;
        }
        public async Task<UserPutDTO> EditAsync(int id, UserPutDTO organizer)
        {
            var url = $"{_url.URLBaseAddress()}{Users}/{id}";
            var edit = await _repositoryCallAPI.Update<UserPutDTO, UserPutDTO>(url, id, organizer);
            return edit;
        }
        public async Task<UserPassword> PasswordAsync(int id, UserPassword userPassword)
        {
            var url = $"{_url.URLBaseAddress()}{Users}/{id}";
            var password = await _repositoryCallAPI.Update<UserPassword, UserPassword>(url, id, userPassword);
            return password;
        }
        public async Task DeleteAsync(int id)
        {
            var url = $"{_url.URLBaseAddress()}{Users}/{id}";
            await _repositoryCallAPI.Delete(url, id);
        }
    }
}
