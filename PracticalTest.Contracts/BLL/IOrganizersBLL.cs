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
        Task<JsonOrganizer> GetAllOrganizersAsync(int page, int perPage);
        Task<OrganizerDTO> GetOrganizersAsync(int Id);
        Task<Organizers> InsertAsync(OrganizerCreateDTO organizerCreateDTO);
        Task<OrganizerCreateDTO> EditAsync(int id, OrganizerCreateDTO organizerCreateDTO);
        Task Delete(int id);
    }
}
