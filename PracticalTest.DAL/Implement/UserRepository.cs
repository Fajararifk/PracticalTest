﻿using Microsoft.EntityFrameworkCore;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PracticalTest_DBContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<User> GetUserByName(string name)
        {
            return await FindByCondition(x => x.FirstName.Equals(name)).FirstOrDefaultAsync();
        }
        public void Insert(User user)
        {
            Create(user);
        }
        public void Edit(User user)
        {
            Update(user);
        }
        public void Remove(User user)
        {
            Delete(user);
        }
        public void Save() => _dbContext.SaveChanges();

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}