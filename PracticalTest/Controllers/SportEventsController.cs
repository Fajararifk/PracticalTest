using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Polly.Retry;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/sportevents")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SportEventsController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        //private readonly HttpClient _httpClient;
       //private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;
        private readonly ISportEventsRepository _repository;
        private readonly ILogger<SportEventsController> _logger;
        private readonly IMapper _mapper;
        private readonly ISportEventsBLL _sportEventsBLL;

        public SportEventsController(ISportEventsBLL sportEventsBLL, ILogger<SportEventsController> logger, IMapper mapper)
        {
            _sportEventsBLL = sportEventsBLL;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSportEvents(int page, int perPage, int organizerID)
        {
            try
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

                var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvYXBpLXNwb3J0LWV2ZW50cy5waHA2LTAyLnRlc3Qudm94dGVuZW8uY29tXC9hcGlcL3YxXC91c2Vyc1wvbG9naW4iLCJpYXQiOjE2ODU0NTQxMzAsImV4cCI6MTY4NTU0MDUzMCwibmJmIjoxNjg1NDU0MTMwLCJqdGkiOiJhN1N2ZXNaa2NOUkdzWVJJIiwic3ViIjoyMDE1LCJwcnYiOiI4N2UwYWYxZWY5ZmQxNTgxMmZkZWM5NzE1M2ExNGUwYjA0NzU0NmFhIn0.ifRQc5PZD2eEZROROMjFtIJ48Z0ZMpstGpAuzJmTQ4Y"; //await HttpContext.GetTokenAsync("");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;
                client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync($"sport-events?page={page}&perPage={perPage}&organizerId={organizerID}");
                var result = response.Content.ReadAsStringAsync().Result;
                var parse = JsonObject.Parse(result);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEvents)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "userbyidEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSportEvents(int id)
        {
            try
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

                var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvYXBpLXNwb3J0LWV2ZW50cy5waHA2LTAyLnRlc3Qudm94dGVuZW8uY29tXC9hcGlcL3YxXC91c2Vyc1wvbG9naW4iLCJpYXQiOjE2ODU0NTQxMzAsImV4cCI6MTY4NTU0MDUzMCwibmJmIjoxNjg1NDU0MTMwLCJqdGkiOiJhN1N2ZXNaa2NOUkdzWVJJIiwic3ViIjoyMDE1LCJwcnYiOiI4N2UwYWYxZWY5ZmQxNTgxMmZkZWM5NzE1M2ExNGUwYjA0NzU0NmFhIn0.ifRQc5PZD2eEZROROMjFtIJ48Z0ZMpstGpAuzJmTQ4Y"; //await HttpContext.GetTokenAsync("");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;
                client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync($"sport-events/{id}");
                var result = response.Content.ReadAsStringAsync().Result;
                var parse = JsonObject.Parse(result);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEvents)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateSportEvents(SportEventsCreateAPIDTO sportEventsDTO)
        {
            try
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

                var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvYXBpLXNwb3J0LWV2ZW50cy5waHA2LTAyLnRlc3Qudm94dGVuZW8uY29tXC9hcGlcL3YxXC91c2Vyc1wvbG9naW4iLCJpYXQiOjE2ODU0NTQxMzAsImV4cCI6MTY4NTU0MDUzMCwibmJmIjoxNjg1NDU0MTMwLCJqdGkiOiJhN1N2ZXNaa2NOUkdzWVJJIiwic3ViIjoyMDE1LCJwcnYiOiI4N2UwYWYxZWY5ZmQxNTgxMmZkZWM5NzE1M2ExNGUwYjA0NzU0NmFhIn0.ifRQc5PZD2eEZROROMjFtIJ48Z0ZMpstGpAuzJmTQ4Y"; //await HttpContext.GetTokenAsync("");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;
                client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders
                    .TryAddWithoutValidation(HeaderNames.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                var JsonData = JsonConvert.SerializeObject(sportEventsDTO);
                var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsJsonAsync($"sport-events", content);
                var result = response.Content.ReadAsStringAsync().Result;
                var parse = JsonObject.Parse(result);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(CreateSportEvents)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSportEvents(int id)
        {
            try
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

                var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvYXBpLXNwb3J0LWV2ZW50cy5waHA2LTAyLnRlc3Qudm94dGVuZW8uY29tXC9hcGlcL3YxXC91c2Vyc1wvbG9naW4iLCJpYXQiOjE2ODU0NTQxMzAsImV4cCI6MTY4NTU0MDUzMCwibmJmIjoxNjg1NDU0MTMwLCJqdGkiOiJhN1N2ZXNaa2NOUkdzWVJJIiwic3ViIjoyMDE1LCJwcnYiOiI4N2UwYWYxZWY5ZmQxNTgxMmZkZWM5NzE1M2ExNGUwYjA0NzU0NmFhIn0.ifRQc5PZD2eEZROROMjFtIJ48Z0ZMpstGpAuzJmTQ4Y"; //await HttpContext.GetTokenAsync("");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;
                client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync($"sport-events/{id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(DeleteSportEvents)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSportEvents(int id, [FromBody] SportEventsCreateAPIDTO sportEventsCreateDTO)
        {
            try
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

                var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvYXBpLXNwb3J0LWV2ZW50cy5waHA2LTAyLnRlc3Qudm94dGVuZW8uY29tXC9hcGlcL3YxXC91c2Vyc1wvbG9naW4iLCJpYXQiOjE2ODU0NTQxMzAsImV4cCI6MTY4NTU0MDUzMCwibmJmIjoxNjg1NDU0MTMwLCJqdGkiOiJhN1N2ZXNaa2NOUkdzWVJJIiwic3ViIjoyMDE1LCJwcnYiOiI4N2UwYWYxZWY5ZmQxNTgxMmZkZWM5NzE1M2ExNGUwYjA0NzU0NmFhIn0.ifRQc5PZD2eEZROROMjFtIJ48Z0ZMpstGpAuzJmTQ4Y"; //await HttpContext.GetTokenAsync("");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;
                client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var JsonData = JsonConvert.SerializeObject(sportEventsCreateDTO);
                var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"organizers/{id}", content);
                var parse = JsonObject.Parse(JsonData);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(UpdateSportEvents)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
