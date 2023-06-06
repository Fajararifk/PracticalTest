using AutoMapper;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO.Create;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace PracticalTest.DAL.Implement
{
    public class LoginToAPI : ILoginToAPI
    {
        private PracticalTest_DBContext _dbContext;
        const string User = "far@voxteneooo.com";
        const string Password = "Pass@w0rd1@";
        public LoginToAPI(PracticalTest_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        private static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp); //
        }

        public async Task<string> LoginAPI()
        {
            var userToken = _dbContext.Users.FirstOrDefault(x => x.EmailAddress == User)?.Token;
            var accessToken = string.Empty;
            if (!String.IsNullOrEmpty(userToken))
            {
                var handlerToken = new JwtSecurityTokenHandler();
                var jwtToken = handlerToken.ReadJwtToken(userToken);
                var expirationDateStrings = jwtToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
                var expirationDateInt = Convert.ToInt32(expirationDateStrings);
                var expirationDate = ConvertFromUnixTimestamp(expirationDateInt);
                if (expirationDate < DateTime.Now)
                {
                    var clientLogin = new HttpClient();
                    clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
                    var login = new User() { Email = User, Password = Password };
                    var postLogin = await clientLogin.PostAsJsonAsync("login", login);
                    var token = postLogin.Content.ReadAsStringAsync().Result;
                    var parseToken = JsonObject.Parse(token);
                    accessToken = parseToken["token"].ToString();
                }
                else
                {
                    accessToken = userToken;
                }
            }
            else
            {
                var clientLogin = new HttpClient();
                clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
                var login = new User() { Email = User, Password = Password };
                var postLogin = await clientLogin.PostAsJsonAsync("login", login);
                var token = postLogin.Content.ReadAsStringAsync().Result;
                var parseToken = JsonObject.Parse(token);
                accessToken = parseToken["token"].ToString();
            }
            TokenToDatabase(accessToken);
            return accessToken;
        }

        public void TokenToDatabase(string token)
        {          
            var tokenEmail = _dbContext.Users.FirstOrDefault(x => x.EmailAddress == User)?.Token;
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
                AccessFailedCount = 1,
            };
            if (tokenEmail == null)
            {
                _dbContext.Users.Add(userToken);
                _dbContext.SaveChanges();
            }
            else
            {
                //_dbContext.Update(userToken);
                var entry = _dbContext.Entry(userToken);
                entry.CurrentValues.SetValues(User);
                _dbContext.SaveChanges();
            }
        }
    }
}
