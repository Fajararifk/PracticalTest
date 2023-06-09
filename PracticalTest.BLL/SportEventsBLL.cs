using AutoMapper;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
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
                var delete = _sportEventsRepository.DeleteAsync(id);
                return delete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(Delete)} message : {ex}");
                _logger.LogDebug(ex.Data.Values.ToString());
                throw new BLLException(ExceptionCodes.BLLExceptions.DeleteAsync, $"An error occured while getting DeleteAsync {ex.ToString()}");
            }
        }

        public async Task<SportEventsCreateAPIDTO> EditAsync(int id, SportEventsCreateAPIDTO sportEventsDTO)
        {
            try
            {
                var sportEvents = await _sportEventsRepository.EditAsync(id, sportEventsDTO);
                return sportEvents;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(EditAsync)} message : {ex}");
                _logger.LogDebug(ex.Data.Values.ToString());
                throw new BLLException(ExceptionCodes.BLLExceptions.UpdateAsync, $"An error occured while getting UpdateAsync {ex.ToString()}");
            }
            
        }

        public async Task<JsonSportEventsAll> GetAllSportEventsAsync(int page, int perPage, int organizerID)
        {
            try
            {
                var sportEvent = await _sportEventsRepository.GetAllSportEventsAsync(page, perPage, organizerID);
                return sportEvent;
                
            }
            catch (Exception ex) 
            {
                _logger.LogError($"{nameof(GetAllSportEventsAsync)} message : {ex.Message}");
                _logger.LogDebug(ex.Data.Values.ToString());
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
                _logger.LogError($"{nameof(GetSportEventsAsync)} message : {ex}");
                _logger.LogDebug(ex.Data.Values.ToString());
                throw new BLLException(ExceptionCodes.BLLExceptions.GetSportEventsAsync, $"An error occured while getting GetSportEventsAsync {ex.ToString()}");
            }
            
        }

        public Task<SportEventsResponseAPIDTO> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO)
        {
            try
            {
                var insert = _sportEventsRepository.InsertAsync(sportEventsCreateAPIDTO);
                return insert;

            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(InsertAsync)} message : {ex}");
                _logger.LogDebug(ex.Data.Values.ToString());
                throw new BLLException(ExceptionCodes.BLLExceptions.InsertAsync, $"An error occured while getting InsertAsync {ex.ToString()}");
            }
        }

    }
}
