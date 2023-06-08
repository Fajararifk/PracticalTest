using Microsoft.AspNetCore.Mvc;
using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
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
        Task<JsonOrganizer> GetAllOrganizerAsync(int page, int perPage);
        Task<Organizers> GetOrganizerByIdAsync(int id);
        Task<Organizers> Insert(OrganizerCreateDTO organizer);
        Task<OrganizerCreateDTO> Edit(int id, OrganizerCreateDTO organizer);
        Task Delete(int id);
    }
}
