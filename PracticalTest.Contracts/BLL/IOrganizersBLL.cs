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
        Task<JsonNode> GetAllOrganizersAsync(int page, int perPage);
        Task<JsonNode> GetOrganizersAsync(int Id);
        Task<JsonNode> InsertAsync(OrganizerCreateDTO organizerCreateDTO);
        Task<JsonNode> EditAsync(int id, OrganizerCreateDTO organizerCreateDTO);
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
