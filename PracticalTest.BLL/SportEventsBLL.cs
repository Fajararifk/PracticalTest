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

namespace PracticalTest.BLL
{
    public class SportEventsBLL :  ISportEventsBLL
    {
        private readonly ISportEventsRepository _sportEventsRepository;
        private readonly IMapper _mapper;

        public SportEventsBLL(ISportEventsRepository sportEventsRepository, IMapper mapper)
        {
            _sportEventsRepository = sportEventsRepository;
            _mapper = mapper;
        }

        public void Delete(SportEventsDTO sportEventsDTO)
        {
            var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
            _sportEventsRepository.Remove(sportEventVM);
            _sportEventsRepository.Save();
        }

        public void Edit(SportEventsDTO sportEventsDTO)
        {
            var sportEventVM = _mapper
                .Map<SportEvents>(sportEventsDTO);
            _sportEventsRepository.Edit(sportEventVM);
            _sportEventsRepository.Save();
        }

        public async Task<IEnumerable<SportEventsDTO>> GetAllSportEvents()
        {
            var sportEventVM = await _sportEventsRepository.GetAllSportEvents();
            var sportEventDTO = _mapper
                .Map<IEnumerable<SportEventsDTO>>(sportEventVM);
            return sportEventDTO;
        }

        public async Task<SportEventsDTO> GetSportEvents(int id)
        {
            var sportEventVM = await _sportEventsRepository.GetSportEventsById(id);
            var sportEventDTO = _mapper
                .Map<SportEventsDTO>(sportEventVM);
            return sportEventDTO;
        }

        public void Insert(SportEventsDTO userDTO)
        {
            var sportEventVM = _mapper
                .Map<SportEvents>(userDTO);
            _sportEventsRepository.Insert(sportEventVM);
            _sportEventsRepository.Save();
        }
    }
}
