using Microsoft.EntityFrameworkCore;
using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.Implement
{
    public class OrganizerRepository : RepositoryBase<Organizers>, IOrganizerRepository
    {
        public OrganizerRepository(PracticalTest_DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Organizers>> GetAllOrganizer()
        {
            return await FindAll().AsNoTracking().ToListAsync();
        }

        public async Task<Organizers> GetOrganizerById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void Insert(Organizers organizer)
        {
            Create(organizer);
        }

        public void Edit(Organizers organizer)
        {
            Update(organizer);
        }

        public void Remove(Organizers organizer)
        {
            Delete(organizer);
        }
    }
}
