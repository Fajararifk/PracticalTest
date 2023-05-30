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
    [Route("api/v1/organizers")]
    public class OrganizersController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        private readonly IOrganizerRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IOrganizersBLL _organizersBLL;

        public OrganizersController(IOrganizersBLL organizersBLL, ILoggerManager logger, IMapper mapper)
        {
            _organizersBLL = organizersBLL;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var users = await _organizersBLL.GetAllOrganizersAsync();
 
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetUser)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizers(int id)
        {
            if (id == null)
            {
                _logger.LogInfo($"Users with name : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var users = await _organizersBLL.GetOrganizersAsync(id);
                return Ok(users);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganizers(OrganizerDTO organizerDTO)
        {
            if (organizerDTO == null)
            {
                _logger.LogError("name object is null");
                return BadRequest("name object is null");
            }
            _organizersBLL.Insert(organizerDTO);
            return Ok(organizerDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizers(int id)
        {
            if (id == null)
            {
                _logger.LogError("id object is null");
                return BadRequest("id object is null");
            }
            var organizers = await _organizersBLL.GetOrganizersAsync(id);
            _organizersBLL.Delete(organizers);
            return Ok(organizers);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganizers(int id)
        {
            if (id == null)
            {
                _logger.LogError("id object is null");
                return BadRequest("id object is null");
            }
            var organizers = await _organizersBLL.GetOrganizersAsync(id);
            _organizersBLL.Edit(organizers);
            return Ok(organizers);
        }
    }
}
