using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddressAsync();
        Task<Address> GetAddressAsync(int id);
        void Insert(Address user);
        void Edit(Address user);
        void Remove(Address user);
        void Save();
        Task SaveAsync();
    }
}
