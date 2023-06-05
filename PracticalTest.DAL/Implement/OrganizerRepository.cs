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
        private PracticalTest_DBContext _dbContext;
        const string User = "far@voxteneooo.com";
        const string Password = "Pass@w0rd1@";

        public OrganizerRepository(PracticalTest_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp); //
        }
        private async Task<string> LoginAPI()
        {
            var userToken = _dbContext.Users.Where(x=>x.EmailAddress == User).Select(x => x.Token).FirstOrDefault();
            var accessToken = string.Empty;
            if (userToken != null)
            {
                JwtSecurityTokenHandler handlerToken = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handlerToken.ReadJwtToken(userToken);
                string expirationDateStrings = jwtToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
                int expirationDateInt = Convert.ToInt32(expirationDateStrings);
                DateTime expirationDate = ConvertFromUnixTimestamp(expirationDateInt);
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
        private void TokenToDatabase(string token) 
        {
            var tokenEmail = _dbContext.Users.Where(x=>x.EmailAddress == User).Select(x=> new { x.Token}).FirstOrDefault();
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
               AccessFailedCount = 0,
            };
            if (tokenEmail.Token == null)
            {
                _dbContext.Users.Add(userToken);
                _dbContext.SaveChanges();
            }
            else
            {
                _dbContext.Entry(userToken).CurrentValues.SetValues(User);
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
            var jsonData = JsonConvert.SerializeObject(organizer);
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
            var jsonData = JsonConvert.SerializeObject(organizer);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"organizers", content);
            var result = response.Content.ReadAsStringAsync().Result;
            var parse = JsonObject.Parse(result);
            return parse;
        }

    }
}
