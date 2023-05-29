using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.Service;
using PracticalTest.DTO;
using System.Xml.Linq;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/sportevents")]
    public class SportEventsController : Controller
    {
        private readonly PracticalTest_DBContext _context;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;

        public SportEventsController(IServiceManager serviceManager, ILoggerManager logger, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSportEvents()
        {
            try
            {
                var users = await _serviceManager.SportEventsService.GetAllSportEvents();
 
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetSportEvents)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id}", Name = "userbyidEvents")]
        public async Task<IActionResult> GetSportEvents(int id)
        {
            if (id == null)
            {
                _logger.LogInfo($"SportEvents with id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var users = await _serviceManager.SportEventsService.GetSportEvents(id);
                return Ok(users);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSportEvents(SportEventsDTO sportEventsDTO)
        {
            if (sportEventsDTO == null)
            {
                _logger.LogError("name object is null");
                return BadRequest("name object is null");
            }
            _serviceManager.SportEventsService.Insert(sportEventsDTO);
            return Ok(sportEventsDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportEvents(int id)
        {
            if (id == null)
            {
                _logger.LogError("id object is null");
                return BadRequest("id object is null");
            }
            var sportEvents = await _serviceManager.SportEventsService.GetSportEvents(id);
            _serviceManager.SportEventsService.Delete(sportEvents);
            return Ok(sportEvents);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSportEvents(int id)
        {
            if (id == null)
            {
                _logger.LogError("id object is null");
                return BadRequest("id object is null");
            }
            var sportEvents = await _serviceManager.SportEventsService.GetSportEvents(id);
            _serviceManager.SportEventsService.Edit(sportEvents);
            return Ok(sportEvents);
        }
    }
}
