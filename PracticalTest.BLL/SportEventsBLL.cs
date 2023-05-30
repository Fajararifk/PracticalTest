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

        public void Delete(SportEventsDTO sportEventsDTO)
        {
            try
            {
                var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
                _sportEventsRepository.Remove(sportEventVM);
                _sportEventsRepository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(Delete)} message : {ex}");
            }
        }

        public void Edit(SportEventsDTO sportEventsDTO)
        {
            try
            {
                var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
                _sportEventsRepository.Edit(sportEventVM);
                _sportEventsRepository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(Edit)} message : {ex}");
            }
            
        }

        public async Task<IEnumerable<SportEventsDTO>> GetAllSportEventsAsync()
        {
            try
            {
                var sportEventVM = await _sportEventsRepository.GetAllSportEventsAsync();
                var sportEventDTO = _mapper
                    .Map<IEnumerable<SportEventsDTO>>(sportEventVM);
                return sportEventDTO;
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"{nameof(GetAllSportEventsAsync)} message : {ex}");
                throw new BLLException(ExceptionCodes.BLLExceptions.GetAllSportEventsAsync, $"An error occured while getting getAllSportEvents {ex.ToString()}");
            }
            
        }

        public async Task<SportEventsDTO> GetSportEventsAsync(int id)
        {
            try
            {
                var sportEventVM = await _sportEventsRepository.GetSportEventsByIdAsync(id);
                var sportEventDTO = _mapper
                    .Map<SportEventsDTO>(sportEventVM);
                return sportEventDTO;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(GetSportEventsAsync)} message : {ex}");
                throw new BLLException(ExceptionCodes.BLLExceptions.GetSportEventsAsync, $"An error occured while getting GetSportEventsAsync {ex.ToString()}");
            }
            
        }

        public void Insert(SportEventsDTO userDTO)
        {
            try
            {
                var sportEventVM = _mapper
                .Map<SportEvents>(userDTO);
                _sportEventsRepository.Insert(sportEventVM);
                _sportEventsRepository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{nameof(Insert)} message : {ex}");
            }
        }

        public SportEventsDTO SaveSportEvents(SportEventsDTO sportEventsDTO)
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
