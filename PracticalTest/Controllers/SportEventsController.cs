﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using System.Xml.Linq;

namespace PracticalTest.Controllers
{
    [ApiController]
    [Route("api/v1/sportevents")]
    public class SportEventsController : Controller
    {
        private readonly PracticalTest_DBContext _context;
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
        public async Task<IActionResult> GetSportEvents()
        {
            try
            {
                var users = await _sportEventsBLL.GetAllSportEventsAsync();
 
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEvents)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id}", Name = "userbyidEvents")]
        public async Task<IActionResult> GetSportEvents(int id)
        {
            if (id == null)
            {
                _logger.LogInformation($"SportEvents with id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var users = await _sportEventsBLL.GetSportEventsAsync(id);
                return Ok(users);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSportEvents(SportEventsDTO sportEventsDTO)
        {
            if (sportEventsDTO == null)
            {
                _logger.LogInformation("name object is null");
                return BadRequest("name object is null");
            }
            _sportEventsBLL.Insert(sportEventsDTO);
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
            var sportEvents = await _sportEventsBLL.GetSportEventsAsync(id);
            _sportEventsBLL.Delete(sportEvents);
            return Ok(sportEvents);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSportEvents(int id)
        {
            if (id == null)
            {
                _logger.LogInformation("id object is null");
                return BadRequest("id object is null");
            }
            var sportEvents = await _sportEventsBLL.GetSportEventsAsync(id);
            _sportEventsBLL.Edit(sportEvents);
            return Ok(sportEvents);
        }
    }
}
