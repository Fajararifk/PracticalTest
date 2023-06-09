using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface ISportEventsBLL
    {
        Task<JsonSportEventsAll> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        Task<SportEventsDTO> GetSportEventsAsync(int Id);
        Task<SportEventsResponseAPIDTO> InsertAsync(SportEventsCreateAPIDTO organizerCreateDTO);
        Task<SportEventsCreateAPIDTO> EditAsync(int id, SportEventsCreateAPIDTO organizerCreateDTO);
        Task Delete(int id);
    }
}
