using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface ISportEventsRepository
    {
        Task<IEnumerable<SportEvents>> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        Task<SportEvents> GetSportEventsByIdAsync(int id);
        void Insert(SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        void Edit(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        void Delete(int id);
    }
}
