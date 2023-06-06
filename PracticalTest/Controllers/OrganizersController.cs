using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using PracticalTest.BLL;
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
                var users = await _organizersBLL.GetAllOrganizersAsync(page, perPage);

                return Ok(users);
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
                var users = await _organizersBLL.GetOrganizersAsync(id);
                if(users.Id == id)
                    return Ok(users);
                return BadRequest();

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
                _organizersBLL.Insert(organizerDTO);

                return Ok(organizerDTO);
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
                //var organizers = await _organizersBLL.GetOrganizersAsync(id);
                _organizersBLL.Delete(id);
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
                _organizersBLL.Edit(id, organizerCreateDTO);
                return Ok(organizerCreateDTO);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(UpdateOrganizers)} message : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
