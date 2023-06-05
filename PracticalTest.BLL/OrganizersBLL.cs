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
        public async Task<JsonNode> EditAsync(int id, OrganizerCreateDTO organizerCreateDTO)
        {
            //var orgVM = _mapper.Map<Organizers>(userDTO);
            var edit = await _organizerRepository.EditAsync(id, organizerCreateDTO);
            return edit;
        }
        public Task<HttpResponseMessage> DeleteAsync(int id)
        {
            //var orgVM = _mapper.Map<Organizers>(id);
            var delete = _organizerRepository.DeleteAsync(id);
            return delete;
        }
        public async Task<JsonNode> GetAllOrganizersAsync(int page, int perPage)
        {
            var orgVM = await _organizerRepository.GetAllOrganizerAsync(page, perPage);
            //var orgDTO = _mapper.Map<OrganizerDTO>(orgVM);
            return orgVM;
        }

        public async Task<JsonNode> GetOrganizersAsync(int id)
        {
            var orgVM = await _organizerRepository.GetOrganizerByIdAsync(id);
            //var orgDTO = _mapper.Map<OrganizerDTO>(orgVM);
            return orgVM;
        }

        public async Task<JsonNode> InsertAsync(OrganizerCreateDTO organizerCreateDTO)
        {
            //var orgVM = _mapper.Map<Organizers>(userDTO);
            var create = await _organizerRepository.InsertAsync(organizerCreateDTO);
            return create;
        }
    }
}
