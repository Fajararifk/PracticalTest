using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using NSubstitute;
using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
using PracticalTest.DAL.Implement;
using PracticalTest.DTO.Create;
using PracticalTest.DAL;
using System.Security.Policy;

namespace PracticalTest.Test
{
    public class UsersRepositoryTest
    {
        private IUsersBLL _usersBLL;
        private IRepositoryCallAPI _callAPI;
        private MyAPIClient _myAPIClient;
        private URLBase _urlBase;
        private URLBase _url;
        private IUsersRepository _usersRepository;
        private IRepositoryCallAPI _repositoryCallAPI;
        const string Users = "users";
        [Fact]
        public void TestMethod()
        {
            _repositoryCallAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _usersRepository = NSubstitute.Substitute.For<IUsersRepository>();

            const string Users = "users";
            const int page = 1;
            const int perPage = 1;
            var users = new User() { EmailAddress = "bdg@voxteneo.com"};
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
            repository.GetAllUsersAsync(1,1);
            repository.GetUsersByIdAsync(2019);
            repository.InsertAsync(userResponse);
            repository.LoginAsync(userLogin);
            repository.EditAsync(2019,userPut);
            repository.PasswordAsync(2019, userPassword);
            repository.DeleteAsync(2019);



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
            var result = _usersRepository.InsertAsync(user);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserResponseDTO>);
        }
        public void EditUsers()
        {
            var user = new UserPutDTO();
            var result = _usersRepository.EditAsync(2019, user);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserPutDTO>);
        }
        public void DeleteUsers()
        {
            var result = _usersRepository.DeleteAsync(2019);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
        }
        public void GetAllUsers()
        {
            var user = new UserPutDTO();
            var result = _usersRepository.GetAllUsersAsync(1,1);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<JsonOrganizer>);
        }
        public void GetUsersById()
        {
            var user = new UserPutDTO();
            var result = _usersRepository.GetUsersByIdAsync(2019);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<UserResponseDTO>);
        }

    }
}