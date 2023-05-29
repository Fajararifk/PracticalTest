using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.Service;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL
{
    public class SportEventsService :  ISportEventsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SportEventsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Delete(SportEventsDTO sportEventsDTO)
        {
            var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
            _repositoryManager.SportEventRepository
                .Remove(sportEventVM);
            _repositoryManager.Save();
        }

        public void Edit(SportEventsDTO sportEventsDTO)
        {
            var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
            _repositoryManager.SportEventRepository
                .Edit(sportEventVM);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<SportEventsDTO>> GetAllSportEvents()
        {
            var sportEventVM = await _repositoryManager
                .SportEventRepository.GetAllSportEvents();
            var sportEventDTO = _mapper
                .Map<IEnumerable<SportEventsDTO>>(sportEventVM);
            return sportEventDTO;
        }

        public async Task<SportEventsDTO> GetSportEvents(int id)
        {
            var sportEventVM = await _repositoryManager
                .SportEventRepository.GetSportEventsById(id);
            var sportEventDTO = _mapper
                .Map<SportEventsDTO>(sportEventVM);
            return sportEventDTO;
        }

        public void Insert(SportEventsDTO userDTO)
        {
            var sportEventVM = _mapper
                .Map<SportEvents>(userDTO);
            _repositoryManager.SportEventRepository
                .Insert(sportEventVM);
            _repositoryManager.Save();
        }
    }
}
