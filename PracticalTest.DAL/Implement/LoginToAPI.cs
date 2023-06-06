using AutoMapper;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.DAL.Implement
{
    public class LoginToAPI : ILoginToAPI
    {
        private PracticalTest_DBContext _dbContext;
        private IMapper _mapper;
        const string User = "far@voxteneooo.com";
        const string Password = "Pass@w0rd1@";
        public LoginToAPI(PracticalTest_DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        private static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp); //
        }

        public async Task<string> LoginAPI()
        {
            var userToken = _dbContext.Users.FirstOrDefault(x => x.EmailAddress == User)?.Token;
            var accessToken = string.Empty;
            if (!String.IsNullOrEmpty(userToken))
            {
                var handlerToken = new JwtSecurityTokenHandler();
                var jwtToken = handlerToken.ReadJwtToken(userToken);
                var expirationDateStrings = jwtToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
                var expirationDateInt = Convert.ToInt32(expirationDateStrings);
                var expirationDate = ConvertFromUnixTimestamp(expirationDateInt);
                if (expirationDate < DateTime.Now)
                {
                    var clientLogin = new HttpClient();
                    clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
                    var login = new User() { Email = User, Password = Password };
                    var postLogin = await clientLogin.PostAsJsonAsync("login", login);
                    var token = postLogin.Content.ReadAsStringAsync().Result;
                    var parseToken = JsonObject.Parse(token);
                    accessToken = parseToken["token"].ToString();
                }
                else
                {
                    accessToken = userToken;
                }
            }
            else
            {
                var clientLogin = new HttpClient();
                clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
                var login = new User() { Email = User, Password = Password };
                var postLogin = await clientLogin.PostAsJsonAsync("login", login);
                var token = postLogin.Content.ReadAsStringAsync().Result;
                var parseToken = JsonObject.Parse(token);
                accessToken = parseToken["token"].ToString();
            }
            TokenToDatabase(accessToken);
            return accessToken;
        }

        public void TokenToDatabase(string token)
        {          
            var tokenEmail = _dbContext.Users.FirstOrDefault(x => x.EmailAddress == User)?.Token;
            var userToken = new User
            {
                Token = token,
                FirstName = User,
                LastName = User,
                EmailAddress = User,
                Password = Password,
                RepeatPassword = Password,
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 1,
            };
            if (tokenEmail == null)
            {
                _dbContext.Users.Add(userToken);
                _dbContext.SaveChanges();
            }
            else
            {
                //_dbContext.Update(userToken);
                var entry = _dbContext.Entry(userToken);
                entry.CurrentValues.SetValues(User);
                _dbContext.SaveChanges();
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var accessToken = await LoginAPI();
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
            var accessToken = await LoginAPI();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var orgVM = _mapper.Map<Organizers>(organizer);
            var jsonData = JsonConvert.SerializeObject(orgVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"organizers/{id}", content);
            var parse = JsonObject.Parse(jsonData);
            return parse;
        }

        public async Task<JsonNode> GetAllOrganizerAsync(int page, int perPage)
        {
            var accessToken = await LoginAPI();
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
        }

        public async Task<JsonNode> InsertAsync(OrganizerCreateDTO organizer)
        {
            var accessToken = await LoginAPI();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var orgVM = _mapper.Map<Organizers>(organizer);
            var jsonData = JsonConvert.SerializeObject(orgVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"organizers", content);
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

        public async Task<JsonNode> GetOrganizerByIdAsync(int id)
        {
            var accessToken = await LoginAPI();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            var client = new HttpClient(handler);
            var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authheader;
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"organizers/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

        public async Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            var accessToken = await LoginAPI();
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
            var accessToken = await LoginAPI();
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

            var accessToken = await LoginAPI();
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
            var accessToken = await LoginAPI();
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

        public async Task<HttpResponseMessage> DeleteSportEventAsync(int id)
        {
            var accessToken = await LoginAPI();
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
