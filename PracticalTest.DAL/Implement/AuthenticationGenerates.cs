using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace PracticalTest.DAL.Implement
{
    public class AuthenticationGenerates : IAuthenticationGenerate
    {
        private readonly IConfiguration _configuration;
        private readonly MyAPIClient _myAPIClient;
        private readonly URLBase _urlBase;
        private PracticalTest_DBContext _dbContext;
        private readonly IHttpClientFactory _httpClientFactory;
        const string Login = "users/login";
        public AuthenticationGenerates(PracticalTest_DBContext dbContext, IHttpClientFactory httpClientFactory, IConfiguration configuration, MyAPIClient myAPIClient, URLBase urlBase)
        {
            _dbContext = dbContext;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _myAPIClient = myAPIClient;
            _urlBase = urlBase;
        }
        private static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp); //
        }
        private void TokenToDatabase(string token, string email, string firstName, string LastName, string password)
        {
            var tokenEmail = _dbContext.Users.FirstOrDefault(x => x.EmailAddress == email);
            var userToken = new User
            {
                Token = token,
                FirstName = firstName,
                LastName = LastName,
                EmailAddress = email,
                Password = password,
                RepeatPassword = password,
            };
            if (tokenEmail == null)
            {
                _dbContext.Users.Add(userToken);
                _dbContext.SaveChanges();
            }
            else
            {
                tokenEmail.Token = token;
                _dbContext.Users.Update(tokenEmail);
                _dbContext.SaveChanges();
            }
        }
        public async Task<string> AuthenticationGenerate()
        {
            var urlConfig = _urlBase.URLBaseAddress();
            var user = _dbContext.Users.OrderByDescending(u => u.CreateAt).FirstOrDefault();
            var accessToken = string.Empty;
            if (!String.IsNullOrEmpty(user.Token))
            {
                var handlerToken = new JwtSecurityTokenHandler();
                var jwtToken = handlerToken.ReadJwtToken(user.Token);
                var expirationDateStrings = jwtToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
                var expirationDateInt = Convert.ToInt32(expirationDateStrings);
                var expirationDate = ConvertFromUnixTimestamp(expirationDateInt);
                if (expirationDate < DateTime.Now)
                {
                    using (var clientLogin = _httpClientFactory.CreateClient())
                    {
                        clientLogin.BaseAddress = new Uri(urlConfig);
                        var login = new UserCreateFromJSON(){ email = user.EmailAddress, password = user.Password };
                        var postLogin = await clientLogin.PostAsJsonAsync(Login, login);
                        var token = await postLogin.Content.ReadAsStringAsync();
                        var parseToken = JsonObject.Parse(token);
                        var objectToken = parseToken["token"];
                        if(objectToken != null)
                        {
                            accessToken = objectToken.ToString();
                        }
                        else
                        {
                            accessToken = string.Empty;
                        }
                    }
                }
                else
                {
                    accessToken = user.Token;
                }
            }
            else
            {
                using (var clientLogin = _httpClientFactory.CreateClient())
                {
                    clientLogin.BaseAddress = new Uri(urlConfig);
                    var login = new UserCreateFromJSON() { email = user.EmailAddress, password = user.Password };
                    var postLogin = await clientLogin.PostAsJsonAsync("login", login);
                    var token = postLogin.Content.ReadAsStringAsync().Result;
                    var parseToken = JsonObject.Parse(token);
                    accessToken = parseToken["token"].ToString();
                }
            }
            TokenToDatabase(accessToken, user.EmailAddress, user.FirstName, user.LastName, user.Password);
            return accessToken;
        }

       
    }
}
