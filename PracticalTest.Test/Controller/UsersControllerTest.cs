using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PracticalTest.BLL;
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
using PracticalTest.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTest.Test.Controller
{
    public class UsersControllerTest
    {
        private IRepositoryCallAPI _callAPI;
        private MyAPIClient _myAPIClient;
        private URLBase _urlBase;
        private URLBase _url;
        private IUsersRepository _usersRepository;
        private IRepositoryCallAPI _repositoryCallAPI;
        const string Users = "users";
        private UsersBLL _usersBLL;
        private IUsersBLL _usersIBLL;
        private IMapper _mapper;
        private ILogger<UsersAPIController> _logger;
        private UsersAPIController _controller;
        [Fact]
        public async void TestMethod()
        {
            _repositoryCallAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _usersRepository = NSubstitute.Substitute.For<IUsersRepository>();
            _usersBLL = new UsersBLL(_usersRepository, _mapper);
            _controller = new UsersAPIController(_usersIBLL, _logger, _mapper);
            var userResponse = new UserCreateAPIDTO()
            {
                email = "arif@gmail.com",
                firstName = "arif",
                lastName = "kurniawan",
                password = "Pass@w0rd1@",
                repeatPassword = "Pass@w0rd1@"
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
            IUsersRepository repository = Substitute.For<IUsersRepository>();
            await repository.GetAllUsersAsync(1, 1);
            await repository.GetUsersByIdAsync(2019);
            await repository.InsertAsync(userResponse);
            await repository.LoginAsync(userLogin);
            await repository.EditAsync(2019, userPut);
            await repository.PasswordAsync(2019, userPassword);
            await repository.DeleteAsync(2019);
            IUsersBLL bll = Substitute.For<IUsersBLL>();
            await bll.GetAllUsersAsync(1, 1);
            await bll.GetUsersAsync(2019);
            await bll.Insert(userResponse);
            await bll.Edit(2019, userPut);
            await bll.Login(userLogin);
            await bll.Password(2019, userPassword);
            await bll.Delete(2019);
            /*UsersAPIController controller = Substitute.For<UsersAPIController>();
            await controller.GetUserAPI(2019);
            await controller.CreateUsersAPI(userResponse);
            await controller.UpdateUsersAPI(2019, userPut);
            await controller.Login(userLogin);
            await controller.UpdatePassword(2019, userPassword);
            await controller.DeleteUsersAPI(2019);*/




        }
        [TestCleanup]
        public void CleanUp()
        {
            _repositoryCallAPI = null;
            _callAPI = null;
            _usersBLL = null;
            _controller = null;
        }

        [TestMethod, TestCategory("UserRepository")]
        public void InsertUsers()
        {
            var user = new UserCreateAPIDTO();
            var result = _controller.CreateUsersAPI(user);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
        public void EditUsers()
        {
            var user = new UserPutDTO();
            var result = _controller.UpdateUsersAPI(2019, user);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
        public void DeleteUsers()
        {
            var result = _controller.DeleteUsersAPI(2019);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
        public void GetUsersById()
        {
            var user = new UserPutDTO();
            var result = _controller.GetUserAPI(2019);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<IActionResult>);
        }
    }
}
