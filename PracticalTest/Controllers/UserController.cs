﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polly.Retry;
using Polly;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using System.Xml.Linq;
using RestSharp;
using Newtonsoft.Json;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : Controller
    {
        //private const string ReqresAPIBaseURL = "https://reqres.in/api";
        //private readonly HttpClient _httpClient;
        private readonly PracticalTest_DBContext _context;
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserBLL _userBLL;
        private const int _maxApiCallRetries = 3;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy =
            Policy.
                HandleResult<HttpResponseMessage>(response =>
                !response.IsSuccessStatusCode)
                .WaitAndRetryAsync(_maxApiCallRetries,
                retryAttempt => TimeSpan.FromSeconds(retryAttempt));

        public UserController(IUserBLL userBLL, ILogger<UserController> logger, IMapper mapper/*, HttpClient httpClient*/)
        {
            _userBLL = userBLL;
            _logger = logger;
            _mapper = mapper;
            //_httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                /*const string ReqresAPIBaseURL = "https://localhost:7120/api/v1/users";
                var _httpClient = new HttpClient();
                var userss = await _userBLL.GetAllUsersAsync();
                var client = new RestClient(ReqresAPIBaseURL);*/
                /* varrequest = new RestRequest();
                foreach ( var user in users )
                {
                }
                 **//*//* var request = new RestRequest(ReqresAPIBaseURL, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                var output = response.Content;*/

                /*var userUrl = "";
                foreach (var item in users)
                {
                    userUrl = $"{ReqresAPIBaseURL}/users/{item.FirstName}";
                }
                var httpResponseMessage = await _asyncRetryPolicy.ExecuteAsync(
                    () => 
                    {
                        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, userUrl);
                        return _httpClient.GetAsync(userUrl);
                    });*/
                var users = await _userBLL.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetUser)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{firstName}", Name = "userbyFirstName")]
        public async Task<IActionResult> GetUsers(string name)
        {
            if (name == null)
            {
                _logger.LogInformation($"Users with name : {name} doesn't exist");
                return NotFound();
            }
            else
            {
                var reqresAPIBaseURL = $"https://localhost:7120/api/v1/users/{name}?name={name}";
                var client = new RestClient(reqresAPIBaseURL);
                var request = new RestRequest(reqresAPIBaseURL, Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = await _userBLL.GetUsersAsync(name);
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy, "application/json");
                RestResponse response = await client.GetAsync(request);
                var output = response.Content;
                return Ok(body);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers(UserDTO name)
        {
            if (name == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            _userBLL.Insert(name);
            return Ok(name);
        }
        [HttpDelete("{firstName}")]
        public async Task<IActionResult> DeleteUsers(string name)
        {
            if (name == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            var user = await _userBLL.GetUsersAsync(name);
            _userBLL.Delete(user);
            return View(user);
        }
        [HttpPut("{firstName}")]
        public async Task<IActionResult> UpdateUsers([FromBody]string name)
        {
            if (name == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            var user = await _userBLL.GetUsersAsync(name);
            _userBLL.Edit(user);
            return View(user);
        }
    }
}
