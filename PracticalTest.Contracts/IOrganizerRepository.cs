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
        Task<IEnumerable<Organizers>> GetAllOrganizerAsync(int page, int perPage);
        Task<Organizers> GetOrganizerByIdAsync(int id);
        void Insert(OrganizerCreateDTO organizer);
        void Edit(int id, OrganizerCreateDTO organizer);
        void Delete(int id);
    }
}
