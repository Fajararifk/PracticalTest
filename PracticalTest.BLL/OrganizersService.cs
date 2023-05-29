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
    public class OrganizersService : IOrganizersService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public OrganizersService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public void Delete(OrganizerDTO organizerDTO)
        {
            var orgVM = _mapper.Map<Organizers>(organizerDTO);
            _repositoryManager.OrganizerRepository.Remove(orgVM);
            _repositoryManager.Save();
        }

        public void Edit(OrganizerDTO organizerDTO)
        {
            var orgVM = _mapper.Map<Organizers>(organizerDTO);
            _repositoryManager.OrganizerRepository.Edit(orgVM);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<OrganizerDTO>> GetAllOrganizers()
        {
            var orgVM = await _repositoryManager.OrganizerRepository.GetAllOrganizer();
            var orgDTO = _mapper.Map<IEnumerable<OrganizerDTO>>(orgVM);
            return orgDTO;
        }

        public async Task<OrganizerDTO> GetOrganizers(int id)
        {
            var orgVM = await _repositoryManager.OrganizerRepository.GetOrganizerById(id);
            var orgDTO = _mapper.Map<OrganizerDTO>(orgVM);
            return orgDTO;
        }

        public void Insert(OrganizerDTO userDTO)
        {
            var orgVM = _mapper.Map<Organizers>(userDTO);
            _repositoryManager.OrganizerRepository.Insert(orgVM);
            _repositoryManager.Save();
        }
    }
}
