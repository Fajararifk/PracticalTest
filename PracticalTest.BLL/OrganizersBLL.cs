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
        public async Task<JsonOrganizer> GetAllOrganizersAsync(int page, int perPage)
        {
            var organizers = await _organizerRepository.GetAllOrganizerAsync(page, perPage);
            return organizers;
        }
        public Task<OrganizerCreateDTO> EditAsync(int id, OrganizerCreateDTO organizerCreateDTO)
        {
            var edit = _organizerRepository.EditAsync(id, organizerCreateDTO);
            return edit;
        }
        public Task Delete(int id)
        {
            var delete = _organizerRepository.DeleteAsync(id);
            return delete;
            
        }

        public async Task<OrganizerDTO> GetOrganizersAsync(int id)
        {
            var organizers = await _organizerRepository.GetOrganizerByIdAsync(id);
            var organizersDTO = _mapper.Map<OrganizerDTO>(organizers);
            return organizersDTO;
        }

        public async Task<Organizers> InsertAsync(OrganizerCreateDTO organizerCreateDTO)
        {
            var insert = await _organizerRepository.InsertAsync(organizerCreateDTO);
            return insert;
        }
    }
}
