using AutoMapper;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IOrganizersService> _lazyorganizerService;
        private readonly Lazy<ISportEventsService> _lazySportEventsService;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _lazySportEventsService = new Lazy<ISportEventsService>(() => new SportEventsService(repositoryManager, mapper));
            _lazyorganizerService = new Lazy<IOrganizersService>(() => new OrganizersService(repositoryManager, mapper));
        }

        public IUserService UserService => _lazyUserService.Value;

        public IOrganizersService OrganizersService => _lazyorganizerService.Value;

        public ISportEventsService SportEventsService => _lazySportEventsService.Value;
    }
}
