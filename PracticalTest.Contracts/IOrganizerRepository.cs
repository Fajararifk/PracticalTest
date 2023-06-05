using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.DTO.Create;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IOrganizerRepository
    {
        Task<JsonNode> GetAllOrganizerAsync(int page, int perPage);
        Task<JsonNode> GetOrganizerByIdAsync(int id);
        Task<JsonNode> InsertAsync(OrganizerCreateDTO organizer);
        Task<JsonNode> EditAsync(int id, OrganizerCreateDTO organizer);
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
