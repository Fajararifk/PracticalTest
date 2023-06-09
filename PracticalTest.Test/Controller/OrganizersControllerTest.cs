using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts.BLL;
using PracticalTest.Contracts;
using PracticalTest.DAL.Implement;
using PracticalTest.DTO.Create;
using PracticalTest.DTO;
using Microsoft.Extensions.Logging;
using PracticalTest.Controllers;
using AutoMapper;
using PracticalTest.BLL;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTest.Test.Controller
{
    public class OrganizersControllerTest
    {
        private IRepositoryCallAPI _callAPI;        
        private IOrganizerRepository _organizersRepository;        
        private OrganizersBLL _organizersBLL;
        private IOrganizersBLL _organizersIBLL;
        private IMapper _mapper;
        private ILogger<OrganizersController> _logger;
        private OrganizersController _controller;
        [Fact]
        public async void TestMethod()
        {
            _callAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _organizersRepository = NSubstitute.Substitute.For<IOrganizerRepository>();
            _organizersBLL = new OrganizersBLL(_organizersRepository, _mapper);
            _controller = new OrganizersController(_organizersIBLL, _logger, _mapper);
            var organizerCreate = new OrganizerCreateDTO()
            {
                organizerName = "arif",
                imageLocation = "www.google.com"
            };
            var userLogin = new UserLogin()
            {
                email = "arif@gmail.com",
                password = "Pass@w0rd1@"
            };
            var userPut = new UserPutDTO()
            {
                email = "arif@gmail.com",
                firstName = "fajar",
                lastName = "arif"
            };
            var userPassword = new UserPassword()
            {
                oldPassword = "Pass@w0rd1@",
                newPassword = "Pass@w0rd1@@",
                repeatPassword = "Pass@w0rd1@@"
            };
            IOrganizerRepository repository = Substitute.For<IOrganizerRepository>();
            IOrganizersBLL bll = Substitute.For<IOrganizersBLL>();
            await repository.GetAllOrganizerAsync(1, 1);
            await repository.GetOrganizerByIdAsync(960);
            await repository.InsertAsync(organizerCreate);
            await repository.EditAsync(960, organizerCreate);
            await repository.DeleteAsync(960);
            await bll.GetAllOrganizersAsync(1, 1);
            await bll.GetOrganizersAsync(960);
            await bll.InsertAsync(organizerCreate);
            await bll.EditAsync(960, organizerCreate);
            await bll.Delete(960);
            /*OrganizersController controller = Substitute.For<OrganizersController>();
            await controller.GetAllOrganizers(1, 1);
            await controller.GetOrganizers(960);
            await controller.CreateOrganizers(organizerCreate);
            await controller.UpdateOrganizers(960, organizerCreate);
            await controller.DeleteOrganizers(960);*/


        }
        [TestCleanup]
        public void CleanUp()
        {
            _callAPI = null;
            _organizersBLL = null;
        }

        [TestMethod, TestCategory("OrganizersRepository")]
        public void InsertOrganizers()
        {
            var organizer = new OrganizerCreateDTO();
            var result = _controller.CreateOrganizers(organizer);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
        public void EditOrganizer()
        {
            var organizer = new OrganizerCreateDTO();
            var result = _controller.UpdateOrganizers(2019, organizer);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
        public void DeleteOrganizers()
        {
            var result = _controller.DeleteOrganizers(950);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
        }
        public void GetAllOrganizers()
        {
            var user = new UserPutDTO();
            var result = _controller.GetAllOrganizers(1, 1);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
        public void GetOrganizersById()
        {
            var user = new UserPutDTO();
            var result = _controller.GetOrganizers(950);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
    }
}
