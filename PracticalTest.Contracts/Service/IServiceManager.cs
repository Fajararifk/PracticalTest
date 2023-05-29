using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.Service
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IOrganizersService OrganizersService { get; }
        ISportEventsService SportEventsService { get; }
    }
}
