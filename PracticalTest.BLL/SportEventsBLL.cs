using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PracticalTest.BLL.Exceptions;
using PracticalTest.DTO.Create;

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

        public Task Delete(int id)
        {
            try
            {
                var delete = _sportEventsRepository.Delete(id);
                return delete;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(Delete)} message : {ex}");
                return Task.Delay(1000);
            }
        }

        public Task<SportEventsCreateAPIDTO> Edit(int id, SportEventsCreateAPIDTO sportEventsDTO)
        {
            try
            {
                var sportEvents = _sportEventsRepository.Edit(id, sportEventsDTO);
                return sportEvents;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(Edit)} message : {ex}");
                return null;
            }
            
        }

        public async Task<JsonSportEventsAll> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            try
            {
                var sportEvent = await _sportEventsRepository.GetAllSportEventsAsync(page, perPage, organizerID);

                //var sportEventDTO = _mapper.Map<string>(sportEvent);
                return sportEvent;
                
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"{nameof(GetAllSportEventsAsync)} message : {ex.Message}");
                throw new BLLException(ExceptionCodes.BLLExceptions.GetAllSportEventsAsync, $"An error occured while getting getAllSportEvents {ex.ToString()}");
            }
            
        }

        public async Task<SportEventsDTO> GetSportEventsAsync(int id)
        {
            try
            {
                var sportEventVM = await _sportEventsRepository.GetSportEventsByIdAsync(id);
                var sportEventDTO = _mapper.Map<SportEventsDTO>(sportEventVM);
                return sportEventDTO;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEventsAsync)} message : {ex}");
                throw new BLLException(ExceptionCodes.BLLExceptions.GetSportEventsAsync, $"An error occured while getting GetSportEventsAsync {ex.ToString()}");
            }
            
        }

        public Task<SportEventsResponseAPIDTO> Insert(SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            try
            {
                var insert = _sportEventsRepository.Insert(sportEventsCreateAPIDTO);
                return insert;

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(Insert)} message : {ex}");
                return null;
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
