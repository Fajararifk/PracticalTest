using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL
{
    public class OrganizersBLL : IOrganizersBLL
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;
        public OrganizersBLL(IOrganizerRepository organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }
        public void Delete(OrganizerDTO organizerDTO)
        {
            var orgVM = _mapper.Map<Organizers>(organizerDTO);
            _organizerRepository.Remove(orgVM);
            _organizerRepository.Save();
        }

        public void Edit(OrganizerDTO organizerDTO)
        {
            var orgVM = _mapper.Map<Organizers>(organizerDTO);
            _organizerRepository.Edit(orgVM);
            _organizerRepository.Save();
        }

        public async Task<IEnumerable<OrganizerDTO>> GetAllOrganizersAsync()
        {
            var orgVM = await _organizerRepository.GetAllOrganizerAsync();
            var orgDTO = _mapper.Map<IEnumerable<OrganizerDTO>>(orgVM);
            return orgDTO;
        }

        public async Task<OrganizerDTO> GetOrganizersAsync(int id)
        {
            var orgVM = await _organizerRepository.GetOrganizerByIdAsync(id);
            var orgDTO = _mapper.Map<OrganizerDTO>(orgVM);
            return orgDTO;
        }

        public void Insert(OrganizerCreateDTO userDTO)
        {
            var orgVM = _mapper.Map<Organizers>(userDTO);
            _organizerRepository.Insert(orgVM);
            _organizerRepository.Save();
        }
    }
}
