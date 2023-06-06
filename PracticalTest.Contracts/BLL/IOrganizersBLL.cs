using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface IOrganizersBLL
    {
        Task<IEnumerable<OrganizerDTO>> GetAllOrganizersAsync(int page, int perPage);
        Task<OrganizerDTO> GetOrganizersAsync(int Id);
        void Insert(OrganizerCreateDTO organizerCreateDTO);
        void Edit(int id, OrganizerCreateDTO organizerCreateDTO);
        void Delete(int id);
    }
}
