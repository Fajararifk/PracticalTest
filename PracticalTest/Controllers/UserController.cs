using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using System.Xml.Linq;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        private readonly IUserRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IUserBLL _userBLL;

        public UserController(IUserBLL userBLL, ILoggerManager logger, IMapper mapper)
        {
            _userBLL = userBLL;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var users = await _userBLL.GetAllUsers();
 
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetUser)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{firstName}", Name = "userbyFirstName")]
        public async Task<IActionResult> GetUsers(string name)
        {
            if (name == null)
            {
                _logger.LogInfo($"Users with name : {name} doesn't exist");
                return NotFound();
            }
            else
            {
                var users = await _userBLL.GetUsers(name);
                return Ok(users);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers(UserDTO name)
        {
            if (name == null)
            {
                _logger.LogError("name object is null");
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
                _logger.LogError("name object is null");
                return BadRequest("name object is null");
            }
            var user = await _userBLL.GetUsers(name);
            _userBLL.Delete(user);
            return View(user);
        }
        [HttpPut("{firstName}")]
        public async Task<IActionResult> UpdateUsers([FromBody]string name)
        {
            if (name == null)
            {
                _logger.LogError("name object is null");
                return BadRequest("name object is null");
            }
            var user = await _userBLL.GetUsers(name);
            _userBLL.Edit(user);
            return View(user);
        }
    }
}
