using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface ISportEventsBLL
    {
        Task<IEnumerable<SportEventsDTO>> GetAllSportEventsAsync();
        Task<SportEventsDTO> GetSportEventsAsync(int id);
        void Insert(SportEventsCreateDTO sportEventsDTO);
        void Edit(SportEventsDTO sportEventsDTO);
        void Delete(SportEventsDTO sportEventsDTO);
        SportEventsCreateDTO SaveSportEvents(SportEventsCreateDTO sportEventsDTO);
    }
}
