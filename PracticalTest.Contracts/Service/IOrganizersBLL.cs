using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.Service
{
    public interface IOrganizersService
    {
        Task<IEnumerable<OrganizerDTO>> GetAllOrganizers();
        Task<OrganizerDTO> GetOrganizers(int Id);
        void Insert(OrganizerDTO OrganizerDTO);
        void Edit(OrganizerDTO OrganizerDTO);
        void Delete(OrganizerDTO OrganizerDTO);
    }
}
