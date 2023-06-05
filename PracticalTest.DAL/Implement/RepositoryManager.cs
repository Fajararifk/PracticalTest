/*using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private PracticalTest_DBContext _dbContext;
        private IUserRepository _userRepository;
        private IOrganizerRepository _organizerRepository;
        private ISportEventsRepository _sportEventRepository;

        public RepositoryManager(PracticalTest_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IOrganizerRepository OrganizerRepository
        {
            get
            {
                if (_organizerRepository == null)
                {
                    _organizerRepository = new OrganizerRepository(_dbContext);
                }
                return _organizerRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }
        public ISportEventsRepository SportEventRepository
        {
            get
            {
                if (_sportEventRepository == null)
                {
                    _sportEventRepository = new SportEventRepository(_dbContext);
                }
                return _sportEventRepository;
            }
        }

        public void Save() => _dbContext.SaveChanges();

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
*/