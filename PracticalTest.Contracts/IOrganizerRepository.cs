using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IOrganizerRepository
    {
        Task<IEnumerable<Organizers>> GetAllOrganizer();
        Task<Organizers> GetOrganizerById(int id);
        void Insert(Organizers organizer);
        void Edit(Organizers organizer);
        void Remove(Organizers organizer);
    }
}
