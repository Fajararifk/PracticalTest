using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface ISportEventsRepository
    {
        Task<IEnumerable<SportEvents>> GetAllSportEventsAsync();
        Task<SportEvents> GetSportEventsByIdAsync(int id);
        void Insert(SportEvents sportEvents);
        void Edit(SportEvents sportEvents);
        void Remove(SportEvents sportEvents);
        void Save();
        Task SaveAsync();
    }
}
