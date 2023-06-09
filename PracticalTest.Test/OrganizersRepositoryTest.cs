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
    public class OrganizersRepositoryTest
    {
        private IUsersBLL _usersBLL;
        private IRepositoryCallAPI _callAPI;
        private MyAPIClient _myAPIClient;
        private URLBase _urlBase;
        private URLBase _url;
        private IOrganizerRepository _organizersRepository;
        const string Users = "organizers";
        [Fact]
        public void TestMethod()
        {
            _callAPI = NSubstitute.Substitute.For<IRepositoryCallAPI>();
            _organizersRepository = NSubstitute.Substitute.For<IOrganizerRepository>();

            const string Users = "users";
            const int page = 1;
            const int perPage = 1;
            var users = new User() { EmailAddress = "bdg@voxteneo.com" };
            var user = new User();
            var jsonOrganizer = new JsonOrganizer();
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
            repository.GetAllOrganizerAsync(1, 1);
            repository.GetOrganizerByIdAsync(960);
            repository.InsertAsync(organizerCreate);
            repository.EditAsync(960, organizerCreate);
            repository.DeleteAsync(960);



        }
        [TestCleanup]
        public void CleanUp()
        {
            _callAPI = null;
            _usersBLL = null;
        }

        [TestMethod, TestCategory("OrganizersRepository")]
        public void InsertOrganizers()
        {
            var organizer = new OrganizerCreateDTO();
            var result = _organizersRepository.InsertAsync(organizer);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<Organizers>);
        }
        public void EditOrganizer()
        {
            var organizer = new OrganizerCreateDTO();
            var result = _organizersRepository.EditAsync(2019, organizer);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<OrganizerCreateDTO>);
        }
        public void DeleteOrganizers()
        {
            var result = _organizersRepository.DeleteAsync(950);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task);
        }
        public void GetAllOrganizers()
        {
            var user = new UserPutDTO();
            var result = _organizersRepository.GetAllOrganizerAsync(1, 1);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<JsonOrganizer>);
        }
        public void GetOrganizersById()
        {
            var user = new UserPutDTO();
            var result = _organizersRepository.GetOrganizerByIdAsync(950);
            Microsoft.VisualStudio.TestTools.UnitTesting
                .Assert.IsTrue(result is Task<Organizers>);
        }
    }
}
