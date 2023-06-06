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
                var sportEvents = await _sportEventsBLL.GetAllSportEventsAsync(page, perPage, organizerID);
                return Ok(sportEvents);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEvents)} message : {ex.Message}");
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
                var sportEvents = await _sportEventsBLL.GetSportEventsAsync(id);
                return Ok(sportEvents);
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
                _sportEventsBLL.Insert(sportEventsDTO);
                return Ok(sportEventsDTO);
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
                _sportEventsBLL.Delete(id);
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
                _sportEventsBLL.Edit(id, sportEventsCreateDTO);
                return Ok(sportEventsCreateDTO);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(UpdateSportEvents)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
