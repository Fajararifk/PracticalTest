using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using PracticalTest.BLL.Exceptions;
using PracticalTest.DTO.Create;
using System.Text.Json.Nodes;

namespace PracticalTest.BLL
{
    public class SportEventsBLL :  ISportEventsBLL
    {
        private readonly ISportEventsRepository _sportEventsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SportEventsBLL> _logger;

        public SportEventsBLL(ISportEventsRepository sportEventsRepository, IMapper mapper, ILogger<SportEventsBLL> logger)
        {
            _sportEventsRepository = sportEventsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<HttpResponseMessage> DeleteAsync(int id)
        {
            try
            {
                var delete = _sportEventsRepository.DeleteAsync(id);
                return delete;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(DeleteAsync)} message : {ex}");
                var delete = _sportEventsRepository.DeleteAsync(id);
                return delete;
            }
        }

        public async Task<JsonNode> EditAsync(int id, SportEventsCreateAPIDTO sportEventsDTO)
        {
            try
            {
                var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
                var edit =  await _sportEventsRepository.EditAsync(id, sportEventsDTO);
                return edit;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(EditAsync)} message : {ex}");
                return ex.Message;
            }
            
        }

        public async Task<JsonNode> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            try
            {
                var sportEventVM = await _sportEventsRepository.GetAllSportEventsAsync( page, perPage, organizerID);
                return sportEventVM;
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"{nameof(GetAllSportEventsAsync)} message : {ex}");
                throw new BLLException(ExceptionCodes.BLLExceptions.GetAllSportEventsAsync, $"An error occured while getting getAllSportEvents {ex.ToString()}");
            }
            
        }

        public async Task<JsonNode> GetSportEventsAsync(int id)
        {
            try
            {
                var sportEventVM = await _sportEventsRepository.GetSportEventsByIdAsync(id);
                return sportEventVM;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEventsAsync)} message : {ex}");
                throw new BLLException(ExceptionCodes.BLLExceptions.GetSportEventsAsync, $"An error occured while getting GetSportEventsAsync {ex.ToString()}");
            }
            
        }

        public async Task<JsonNode> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            try
            {
                var insert = await _sportEventsRepository.InsertAsync(sportEventsCreateAPIDTO);
                return insert;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(InsertAsync)} message : {ex}");
                return ex.Message;
            }
        }

        public SportEventsCreateDTO SaveSportEvents(SportEventsCreateDTO sportEventsDTO)
        {
            var validationSportEvents = new SportEventsValidator();
            var sportEventVM = _mapper.Map<SportEvents>(sportEventsDTO);
            var validationResult = validationSportEvents.Validate(sportEventVM);
            if(validationResult.Errors.Count > 0)
            {
                throw new ValidationException((IEnumerable<FluentValidation.Results.ValidationFailure>)validationResult);
            }
            return sportEventsDTO;
        }

    }
}
