using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public class SportEventRepository : ISportEventsRepository
    {
        public async Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID)
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
            var response = await client.GetAsync($"sport-events?page={page}&perPage={perPage}&organizerId={organizerID}");
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

        public async Task<JsonNode> GetSportEventsByIdAsync(int id)
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
            var response = await client.GetAsync($"sport-events/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

        public async Task<JsonNode> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
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
            client.DefaultRequestHeaders
                .TryAddWithoutValidation(HeaderNames.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
            var jsonData = JsonConvert.SerializeObject(sportEventsCreateAPIDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"sport-events", content);
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

        public async Task<JsonNode> EditAsync(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
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
            var jsonData = JsonConvert.SerializeObject(sportEventsCreateAPIDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"organizers/{id}", content);
            var parse = JsonObject.Parse(jsonData);
            return parse;
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
            var response = await client.DeleteAsync($"sport-events/{id}");
            return response;
        }
    }
}
