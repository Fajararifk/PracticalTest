﻿using PracticalTest.BusinessObjects;
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
        Task<JsonSportEventsAll> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        Task<SportEvents> GetSportEventsByIdAsync(int id);
        Task<SportEventsResponseAPIDTO> InsertAsync(SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        Task<SportEventsCreateAPIDTO> EditAsync(int id, SportEventsCreateAPIDTO sportEventsCreateAPIDTO);
        Task DeleteAsync(int id);
    }
}
