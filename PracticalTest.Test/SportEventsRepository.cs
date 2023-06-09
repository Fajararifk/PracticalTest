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

namespace PracticalTest.Test
{
    public class SportEventsRepository
    {
        private IUsersBLL _usersBLL;
        private IRepositoryCallAPI _callAPI;
        private MyAPIClient _myAPIClient;
        private URLBase _urlBase;
        private URLBase _url;
        private ISportEventsRepository _sportEventsRepository;
        const string Users = "users";
        [Fact]
        public void TestMethod()
        {
            _callAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _sportEventsRepository = NSubstitute.Substitute.For<ISportEventsRepository>();

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
            repository.GetAllSportEventsAsync(page, perPage, 960);
            repository.GetSportEventsByIdAsync(1335);
            repository.InsertAsync(sportEventsCreate);
            repository.EditAsync(1335, sportEventsCreate);
            repository.DeleteAsync(1335);



        }
        [TestCleanup]
        public void CleanUp()
        {
            _callAPI = null;
            _usersBLL = null;
        }

        [TestMethod, TestCategory("SportEventsRepository")]
        public void InsertSportEvents()
        {
            var sportEvents = new SportEventsCreateAPIDTO();
            var result = _sportEventsRepository.InsertAsync(sportEvents);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<SportEventsResponseAPIDTO>);
        }
        public void EditSportEvents()
        {
            var sportEvents = new SportEventsCreateAPIDTO();
            var result = _sportEventsRepository.EditAsync(1335, sportEvents);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserPutDTO>);
        }
        public void DeleteSportEvents()
        {
            var result = _sportEventsRepository.DeleteAsync(960);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
        }
        public void GetAllSportEvents()
        {
            var result = _sportEventsRepository.GetAllSportEventsAsync(1, 1, 960);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<JsonSportEventsAll>);
        }
        public void GetSportEventsById()
        {
            var result = _sportEventsRepository.GetSportEventsByIdAsync(1335);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<Organizers>);
        }
    }
}
