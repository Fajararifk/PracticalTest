using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface IOrganizersBLL
    {
        Task<IEnumerable<OrganizerDTO>> GetAllOrganizersAsync();
        Task<OrganizerDTO> GetOrganizersAsync(int Id);
        void Insert(OrganizerDTO OrganizerDTO);
        void Edit(OrganizerDTO OrganizerDTO);
        void Delete(OrganizerDTO OrganizerDTO);
    }
}
