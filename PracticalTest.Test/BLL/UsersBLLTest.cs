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
using PracticalTest.BLL;
using AutoMapper;

namespace PracticalTest.Test.BLL
{
    public class UsersBLLTest
    {
        private IRepositoryCallAPI _callAPI;
        private MyAPIClient _myAPIClient;
        private URLBase _urlBase;
        private URLBase _url;
        private IUsersRepository _usersRepository;
        private IRepositoryCallAPI _repositoryCallAPI;
        const string Users = "users";
        private UsersBLL _usersBLL;
        private IMapper _mapper;
        [Fact]
        public void TestMethod()
        {
            _repositoryCallAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _usersRepository = NSubstitute.Substitute.For<IUsersRepository>();
            _usersBLL = new UsersBLL(_usersRepository, _mapper);

            const string Users = "users";
            const int page = 1;
            const int perPage = 1;
            var users = new User() { EmailAddress = "bdg@voxteneo.com" };
            var user = new User();
            var jsonOrganizer = new JsonOrganizer();
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
            repository.GetAllUsersAsync(1, 1);
            repository.GetUsersByIdAsync(2019);
            repository.InsertAsync(userResponse);
            repository.LoginAsync(userLogin);
            repository.EditAsync(2019, userPut);
            repository.PasswordAsync(2019, userPassword);
            repository.DeleteAsync(2019);
            IUsersBLL bll = Substitute.For<IUsersBLL>();
            bll.GetAllUsersAsync(1, 1);
            bll.GetUsersAsync(2019);
            bll.Insert(userResponse);
            bll.Edit(2019, userPut);
            bll.Login(userLogin);
            bll.Password(2019, userPassword);
            bll.Delete(2019);





        }
        [TestCleanup]
        public void CleanUp()
        {
            _repositoryCallAPI = null;
            _callAPI = null;
            _usersBLL = null;
        }

        [TestMethod, TestCategory("UserRepository")]
        public void InsertUsers()
        {
            var user = new UserCreateAPIDTO();
            var result = _usersBLL.Insert(user);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserResponseDTO>);
        }
        public void EditUsers()
        {
            var user = new UserPutDTO();
            var result = _usersBLL.Edit(2019, user);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserPutDTO>);
        }
        public void DeleteUsers()
        {
            var result = _usersBLL.Delete(2019);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
        }
        public void GetAllUsers()
        {
            var user = new UserPutDTO();
            var result = _usersBLL.GetAllUsersAsync(1, 1);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<JsonOrganizer>);
        }
        public void GetUsersById()
        {
            var user = new UserPutDTO();
            var result = _usersBLL.GetUsersAsync(2019);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserResponseDTO>);
        }
    }
}
