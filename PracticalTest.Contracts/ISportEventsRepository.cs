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
        Task<IEnumerable<SportEvents>> GetAllSportEvents();
        Task<SportEvents> GetSportEventsById(int id);
        void Insert(SportEvents sportEvents);
        void Edit(SportEvents sportEvents);
        void Remove(SportEvents sportEvents);
    }
}
