using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts.BLL;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticalTest.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTest.Test.Controller
{
    public class SportEventsControllerTest
    {
        private IRepositoryCallAPI _callAPI;
        private ISportEventsRepository _sportEventsRepository;
        private SportEventsBLL _sportEventsBLL;
        private ISportEventsBLL _sportEventsIBLL;
        private IMapper _mapper;
        private ILogger<SportEventsBLL> _logger;
        private ILogger<SportEventsController> _loggerController;
        private SportEventsController _controller;
        [Fact]
        public async void TestMethod()
        {
            _callAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _sportEventsRepository = NSubstitute.Substitute.For<ISportEventsRepository>();
            _sportEventsBLL = new SportEventsBLL(_sportEventsRepository, _mapper, _logger);
            _controller = new SportEventsController(_sportEventsIBLL, _loggerController, _mapper);
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
            //SportEventsController controller = Substitute.For<SportEventsController>();
            await repository.GetAllSportEventsAsync(page, perPage, 960);
            await repository.GetSportEventsByIdAsync(1335);
            await repository.InsertAsync(sportEventsCreate);
            await repository.EditAsync(1335, sportEventsCreate);
            await repository.DeleteAsync(1335);
            await bll.GetAllSportEventsAsync(page, perPage, 960);
            await bll.GetSportEventsAsync(1335);
            await bll.InsertAsync(sportEventsCreate);
            await bll.EditAsync(1335, sportEventsCreate);
            await bll.Delete(1335);
            //await controller.GetSportEvents(page, perPage, 960);
            //await controller.GetSportEvents(1335);
            //await controller.CreateSportEvents(sportEventsCreate);
            //await controller.UpdateSportEvents(1335, sportEventsCreate);
            //await controller.DeleteSportEvents(1335);


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
            var result = _controller.CreateSportEvents(sportEvents);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
            Microsoft.VisualStudio.TestTools.UnitTesting
            .Assert.IsNotNull(result);
        }
        public void EditSportEvents()
        {
            var sportEvents = new SportEventsCreateAPIDTO();
            var result = _controller.UpdateSportEvents(1335, sportEvents);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
            Microsoft.VisualStudio.TestTools.UnitTesting
            .Assert.IsNotNull(result);
        }
        public void DeleteSportEvents()
        {
            var result = _controller.DeleteSportEvents(960);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
            Microsoft.VisualStudio.TestTools.UnitTesting
            .Assert.IsNotNull(result);
        }
        public void GetAllSportEvents()
        {
            var result = _controller.GetSportEvents(1, 1, 960);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
            Microsoft.VisualStudio.TestTools.UnitTesting
            .Assert.IsNotNull(result);
        }
        public void GetSportEventsById()
        {
            var result = _controller.GetSportEvents(1335);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
            Microsoft.VisualStudio.TestTools.UnitTesting
            .Assert.IsNotNull(result);
        }
    }
}
