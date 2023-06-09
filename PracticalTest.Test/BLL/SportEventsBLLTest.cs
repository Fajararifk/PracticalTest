using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts.BLL;
using PracticalTest.Contracts;
using PracticalTest.DAL.Implement;
using PracticalTest.DTO.Create;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PracticalTest.BLL;
using PracticalTest.DAL;
using Microsoft.Extensions.Logging;

namespace PracticalTest.Test.BLL
{
    public class SportEventsBLLTest
    {
        private IRepositoryCallAPI _callAPI;
        private ISportEventsRepository _sportEventsRepository;
        private SportEventsBLL _sportEventsBLL;
        private IMapper _mapper;
        private ILogger<SportEventsBLL> _logger;
        [Fact]
        public void TestMethod()
        {
            _callAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _sportEventsRepository = NSubstitute.Substitute.For<ISportEventsRepository>();
            _sportEventsBLL = new SportEventsBLL(_sportEventsRepository, _mapper, _logger);

            const string Users = "users";
            const int page = 1;
            const int perPage = 1;
            var sportEventsCreate = new SportEventsCreateAPIDTO()
            {
                eventDate = "2023-09-06",
                eventName = "www.google.com",
                eventType = "google",
                organizerId = 960
            };
            ISportEventsRepository repository = Substitute.For<ISportEventsRepository>();
            ISportEventsBLL bll = Substitute.For<ISportEventsBLL>();
            repository.GetAllSportEventsAsync(page, perPage, 960);
            repository.GetSportEventsByIdAsync(1335);
            repository.InsertAsync(sportEventsCreate);
            repository.EditAsync(1335, sportEventsCreate);
            repository.DeleteAsync(1335);
            bll.GetAllSportEventsAsync(page, perPage, 960);
            bll.GetSportEventsAsync(1335);
            bll.InsertAsync(sportEventsCreate);
            bll.EditAsync(1335, sportEventsCreate);
            bll.Delete(1335);


        }
        [TestCleanup]
        public void CleanUp()
        {
            _callAPI = null;
            _sportEventsBLL = null;
        }

        [TestMethod, TestCategory("SportEventsRepository")]
        public void InsertSportEvents()
        {
            var sportEvents = new SportEventsCreateAPIDTO();
            var result = _sportEventsBLL.InsertAsync(sportEvents);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<SportEventsResponseAPIDTO>);
        }
        public void EditSportEvents()
        {
            var sportEvents = new SportEventsCreateAPIDTO();
            var result = _sportEventsBLL.EditAsync(1335, sportEvents);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserPutDTO>);
        }
        public void DeleteSportEvents()
        {
            var result = _sportEventsBLL.Delete(960);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
        }
        public void GetAllSportEvents()
        {
            var result = _sportEventsBLL.GetAllSportEventsAsync(1, 1, 960);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<JsonSportEventsAll>);
        }
        public void GetSportEventsById()
        {
            var result = _sportEventsBLL.GetSportEventsAsync(1335);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<Organizers>);
        }
    }
}
