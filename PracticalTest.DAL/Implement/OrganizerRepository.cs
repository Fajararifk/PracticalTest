using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace PracticalTest.DAL
{
    public class OrganizerRepository : IOrganizerRepository
    {
        public OrganizerRepository()
        {
        }

        public OrganizerRepository(PracticalTest_DBContext dbContext) /*: base(dbContext)*/
        {
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var user = "far@voxteneooo.com";
            var password = "Pass@w0rd1@";
            var clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
            var login = new User() { Email = user, Password = password };
            var postLogin = await clientLogin.PostAsJsonAsync("login", login);
            var token = postLogin.Content.ReadAsStringAsync().Result;
            var parseToken = JsonObject.Parse(token);
            var accessToken = parseToken["token"].ToString();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync($"organizers/{id}");
            return response;
        }

        public async Task<JsonNode> EditAsync(int id, OrganizerCreateDTO organizer)
        {
            var user = "far@voxteneooo.com";
            var password = "Pass@w0rd1@";
            var clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
            var login = new User() { Email = user, Password = password };
            var postLogin = await clientLogin.PostAsJsonAsync("login", login);
            var token = postLogin.Content.ReadAsStringAsync().Result;
            var parseToken = JsonObject.Parse(token);
            var accessToken = parseToken["token"].ToString();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonData = JsonConvert.SerializeObject(organizer);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"organizers/{id}", content);
            var parse = JsonObject.Parse(jsonData);
            return parse;
        }

        public async Task<JsonNode> GetAllOrganizerAsync(int page, int perPage)
        {
            var user = "far@voxteneooo.com";
            var password = "Pass@w0rd1@";
            var clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
            var login = new User() { Email = user, Password = password };
            var postLogin = await clientLogin.PostAsJsonAsync("login", login);
            var token = postLogin.Content.ReadAsStringAsync().Result;
            var parseToken = JsonObject.Parse(token);
            var accessToken = parseToken["token"].ToString();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"organizers?page={page}&perPage={perPage}");
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
            //return await FindAll().AsNoTracking().ToListAsync();
        }

        public async Task<JsonNode> GetOrganizerByIdAsync(int id)
        {
            var user = "far@voxteneooo.com";
            var password = "Pass@w0rd1@";
            var clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
            var login = new User() { Email = user, Password = password };
            await clientLogin.PostAsJsonAsync("login", login);
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);

            var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvYXBpLXNwb3J0LWV2ZW50cy5waHA2LTAyLnRlc3Qudm94dGVuZW8uY29tXC9hcGlcL3YxXC91c2Vyc1wvbG9naW4iLCJpYXQiOjE2ODU2OTc4MTcsImV4cCI6MTY4NTc4NDIxNywibmJmIjoxNjg1Njk3ODE3LCJqdGkiOiJ1NXNLSDRZMXhyZ09FNFFjIiwic3ViIjoyMDE1LCJwcnYiOiI4N2UwYWYxZWY5ZmQxNTgxMmZkZWM5NzE1M2ExNGUwYjA0NzU0NmFhIn0.MzgY1WwzsTLyTq6Z-Apb9frLm6-sOolr6NPWnfpNAuI";
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"organizers/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;

            //return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<JsonNode> InsertAsync(OrganizerCreateDTO organizer)
        {

            var user = "far@voxteneooo.com";
            var password = "Pass@w0rd1@";
            var clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
            var login = new User() { Email = user, Password = password };
            var postLogin = await clientLogin.PostAsJsonAsync("login", login);
            var token = postLogin.Content.ReadAsStringAsync().Result;
            var parseToken = JsonObject.Parse(token);
            var accessToken = parseToken["token"].ToString();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonData = JsonConvert.SerializeObject(organizer);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"organizers", content);
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

    }
}
