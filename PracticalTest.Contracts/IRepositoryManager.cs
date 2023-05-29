using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IRepositoryManager
    {
        IOrganizerRepository OrganizerRepository { get; }
        IUserRepository UserRepository { get; }
        ISportEventsRepository SportEventRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
