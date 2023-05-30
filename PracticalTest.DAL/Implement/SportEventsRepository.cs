using Microsoft.EntityFrameworkCore;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL
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
        public void Save() => _dbContext.SaveChanges();

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
