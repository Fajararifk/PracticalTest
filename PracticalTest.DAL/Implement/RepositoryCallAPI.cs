using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.DAL.Implement
{
    public class RepositoryCallAPI : IRepositoryCallAPI
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthenticationGenerate _authenticationGenerate;

        private async Task Login(HttpClient client)
        {
            var accessToken = await _authenticationGenerate.AuthenticationGenerate();
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public RepositoryCallAPI(IHttpClientFactory httpClientFactory, IAuthenticationGenerate authenticationGenerate)
        {
            _httpClientFactory = httpClientFactory;
            _authenticationGenerate = authenticationGenerate;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                await Login(client);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var parse = JsonObject.Parse(data);
                    var get = parse.ToJsonString();
                    var generic = JsonConvert.DeserializeObject<IEnumerable<T>>(get);
                    return generic;
                }
                else
                {
                    throw new InvalidOperationException("Get operation failed with status code: " + response.StatusCode);
                }
            }
        }


        public async Task<T> Get<T>(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var uriBase = new Uri(url);
                await Login(client);
                var response = await client.GetAsync(uriBase);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parse = JsonObject.Parse(data);
                    var get = parse.ToJsonString();
                    var generic = JsonConvert.DeserializeObject<T>(get);
                    return generic;
                }
                else
                {
                    throw new InvalidOperationException("GetById operation failed with status code: " + response.StatusCode);
                }
            }
        }

        public async Task<TResponse> Create<TResponse, TRequest>(string url, TRequest entity)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                await Login(client);
                var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parse = JsonObject.Parse(data);
                    var get = parse.ToJsonString();
                    var generic = JsonConvert.DeserializeObject<TResponse>(get);
                    return generic;
                }
                else
                {
                    throw new InvalidOperationException("Create operation failed with status code: " + response.StatusCode);
                }
            }
        }

        public async Task<TResponse> Update<TResponse, TRequest>(string url, int id, TRequest entity)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                await Login(client);
                var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                var uriBase = new Uri(url);
                var uri = new Uri(uriBase, id.ToString());

                var response = await client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<TResponse>();
                    return data;
                }
                else
                {
                    throw new InvalidOperationException("Update operation failed with status code: " + response.StatusCode);
                }
            }
        }

        public async Task Delete(string url, int id)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                await Login(client);
                var uriBase = new Uri(url);
                var uri = new Uri(uriBase, id.ToString());
                var response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException("Delete operation failed with status code: " + response.StatusCode);
                }
            }
        }
    }
}
