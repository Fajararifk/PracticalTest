﻿using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByNameAsync(string name);
        void Insert(User user);
        void Edit(User user);
        void Remove(User user);
        void Save();
        Task SaveAsync();
    }
}
