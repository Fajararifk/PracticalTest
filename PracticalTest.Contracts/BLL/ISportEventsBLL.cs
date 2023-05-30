using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface ISportEventsBLL
    {
        Task<IEnumerable<SportEventsDTO>> GetAllSportEvents();
        Task<SportEventsDTO> GetSportEvents(int id);
        void Insert(SportEventsDTO sportEventsDTO);
        void Edit(SportEventsDTO sportEventsDTO);
        void Delete(SportEventsDTO sportEventsDTO);
    }
}
