using Microsoft.EntityFrameworkCore;
using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.Implement
{
    public class SportEventRepository : RepositoryBase<SportEvents>, ISportEventsRepository
    {
        public SportEventRepository(PracticalTest_DBContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<SportEvents>> GetAllSportEvents()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<SportEvents> GetSportEventsById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public void Insert(SportEvents sportEvents)
        {
            Create(sportEvents);
        }

        public void Edit(SportEvents sportEvents)
        {
            Update(sportEvents);
        }

        public void Remove(SportEvents sportEvents)
        {
            Delete(sportEvents);
        }
    }
}
