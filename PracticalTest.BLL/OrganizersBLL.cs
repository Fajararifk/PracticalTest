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
using System.Text.Json.Nodes;
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
        public async Task<IEnumerable<OrganizerDTO>> GetAllOrganizersAsync(int page, int perPage)
        {
            var orgVM = await _organizerRepository.GetAllOrganizerAsync(page, perPage);
            var orgDTO = _mapper.Map<IEnumerable<OrganizerDTO>>(orgVM);
            return orgDTO;
        }
        public void Edit(int id, OrganizerCreateDTO organizerCreateDTO)
        {
            var orgVM = _mapper.Map<Organizers>(organizerCreateDTO);
            _organizerRepository.Edit(id, organizerCreateDTO);
        }
        public void Delete(int id)
        {
            //var orgVM = _mapper.Map<Organizers>(id);
            _organizerRepository.Delete(id);
            
        }

        public async Task<OrganizerDTO> GetOrganizersAsync(int id)
        {
            var orgVM = await _organizerRepository.GetOrganizerByIdAsync(id);
            var orgDTO = _mapper.Map<OrganizerDTO>(orgVM);
            return orgDTO;
        }

        public void Insert(OrganizerCreateDTO organizerCreateDTO)
        {
            //var orgVM = _mapper.Map<Organizers>(userDTO);
            _organizerRepository.Insert(organizerCreateDTO);
        }
    }
}
