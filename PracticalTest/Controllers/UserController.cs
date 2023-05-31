using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.Net.Mime;
using System.Xml.Linq;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UserController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserBLL _userBLL;

        public UserController(IUserBLL userBLL, ILogger<UserController> logger, IMapper mapper)
        {
            _userBLL = userBLL;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var users = await _userBLL.GetAllUsersAsync();
 
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetUser)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id}", Name = "userbyFirstName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsers(int id)
        {
            if (id == null)
            {
                _logger.LogInformation($"Users with id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var users = await _userBLL.GetUsersAsync(id);
                return Ok(users);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUsers(UserCreateDTO name)
        {
            if (name == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            _userBLL.Insert(name);
            return Ok(name);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            if (id == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            var user = await _userBLL.GetUsersAsync(id);
            _userBLL.Delete(user);
            return View(user);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUsers([FromBody]int id)
        {
            if (id == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            var user = await _userBLL.GetUsersAsync(id);
            _userBLL.Edit(user);
            return View(user);
        }
    }
}
