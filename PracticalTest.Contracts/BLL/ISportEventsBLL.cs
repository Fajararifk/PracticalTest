﻿using PracticalTest.BusinessObjects;
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
        Task<IEnumerable<SportEvents>> GetAllSportEventsAsync(int page, int perPage, int organizerID);
        Task<SportEventsDTO> GetSportEventsAsync(int Id);
        void Insert(SportEventsCreateAPIDTO organizerCreateDTO);
        void Edit(int id, SportEventsCreateAPIDTO organizerCreateDTO);
        void Delete(int id);
    }
}
