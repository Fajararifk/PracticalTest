using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts.BLL;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using System.Net.Mime;
using PracticalTest.DTO;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/usersss")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UsersAPIController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        private readonly IUsersRepository _repository;
        private readonly ILogger<UsersAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersBLL _organizersBLL;

        public UsersAPIController(IUsersBLL organizersBLL, ILogger<UsersAPIController> logger, IMapper mapper)
        {
            _organizersBLL = organizersBLL;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// getAllUsersApi.
        /// </summary>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /*[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsersApi(int page, int perPage)
        {
            try
            {
                var users = await _organizersBLL.GetAllUsersAsync(page, perPage);

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetAllUsersApi)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }*/
        /// <summary>
        /// getUsersApi.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAPI(int id)
        {
            try
            {
                var users = await _organizersBLL.GetUsersAsync(id);
                if (users.id == id)
                    return Ok(users);
                return BadRequest();

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetUserAPI)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// createUsersApi.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUsersAPI(UserCreateAPIDTO organizerDTO)
        {
            try
            {
                var response = await _organizersBLL.Insert(organizerDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(CreateUsersAPI)} message : {ex}");
                return BadRequest(ex.Message);
            }


        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(UserLogin organizerDTO)
        {
            try
            {
                var response = await _organizersBLL.Login(organizerDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(CreateUsersAPI)} message : {ex}");
                return BadRequest(ex.Message);
            }


        }
        /// <summary>
        /// deleteUsersApi.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsersAPI(int id)
        {
            try
            {
                //var organizers = await _organizersBLL.GetOrganizersAsync(id);
                await _organizersBLL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(DeleteUsersAPI)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// updateUsersApi.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUsersAPI(int id, [FromBody] UserPutDTO organizerCreateDTO)
        {
            try
            {
                _organizersBLL.Edit(id, organizerCreateDTO);
                return Ok(organizerCreateDTO);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(UpdateUsersAPI)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// passwordUsersApi.
        /// </summary>
        [HttpPut("{id}/password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] UserPassword organizerCreateDTO)
        {
            try
            {
                _organizersBLL.Password(id, organizerCreateDTO);
                return Ok(organizerCreateDTO);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(UpdatePassword)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}