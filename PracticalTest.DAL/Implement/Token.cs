using PracticalTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL.Implement
{
    public class Token
    {
        private PracticalTest_DBContext _dbContext;
        const string User = "far@voxteneooo.com";
        const string Password = "Pass@w0rd1@";
        public Token(PracticalTest_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void TokenToDatabase(string token)
        {
            var tokenEmail = _dbContext.Users.Where(x => x.EmailAddress == User).Select(x => new { x.Token }).FirstOrDefault();
            var userToken = new User
            {
                Token = token,
                FirstName = User,
                LastName = User,
                EmailAddress = User,
                Password = Password,
                RepeatPassword = Password,
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };
            if (tokenEmail.Token == null)
            {
                _dbContext.Users.Add(userToken);
                _dbContext.SaveChanges();
            }
            else
            {
                _dbContext.Entry(userToken).CurrentValues.SetValues(User);
                _dbContext.SaveChanges();
            }
        }
    }
}
