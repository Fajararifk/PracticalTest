using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/organizers")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrganizersController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        private readonly IOrganizerRepository _repository;
        private readonly ILogger<OrganizersController> _logger;
        private readonly IMapper _mapper;
        private readonly IOrganizersBLL _organizersBLL;

        public OrganizersController(IOrganizersBLL organizersBLL, ILogger<OrganizersController> logger, IMapper mapper)
        {
            _organizersBLL = organizersBLL;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// getAllOrganizers.
        /// </summary>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOrganizers(int page, int perPage)
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
                var response = await client.GetAsync($"organizers?page={page}&perPage={perPage}");
                var result = response.Content.ReadAsStringAsync().Result;
                var parse = JsonObject.Parse(result);
                return Ok(parse);
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"{nameof(GetAllOrganizers)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// getOrganizer.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizers(int id)
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
                var response = await client.GetAsync($"organizers/{id}");
                var result = response.Content.ReadAsStringAsync().Result;
                var parse = JsonObject.Parse(result);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetOrganizers)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// createOrganizer.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOrganizers(OrganizerCreateDTO organizerDTO)
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
                var JsonData = JsonConvert.SerializeObject(organizerDTO);
                var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"organizers", content);
                var result = response.Content.ReadAsStringAsync().Result;
                var parse = JsonObject.Parse(result);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(CreateOrganizers)} message : {ex}");
                return BadRequest(ex.Message);
            }
            

        }
        /// <summary>
        /// deleteOrganizer.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrganizers(int id)
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
                var response = await client.DeleteAsync($"organizers/{id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(DeleteOrganizers)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// updateOrganizer.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrganizers(int id, [FromBody] OrganizerCreateDTO organizerCreateDTO)
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
                var JsonData = JsonConvert.SerializeObject(organizerCreateDTO);
                var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"organizers/{id}", content);
                var parse = JsonObject.Parse(JsonData);
                return Ok(parse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(UpdateOrganizers)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
