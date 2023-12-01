using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace PracticalTest.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserBLL(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void Delete(UserDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _userRepository.Remove(userVM);
            _userRepository.Save();
        }

        public void Edit(UserDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _userRepository.Edit(userVM);
            _userRepository.Save();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userVM = await _userRepository.GetAllUserAsync();
            return userVM;
        }

        public async Task<UserDTO> GetUsersAsync(int id)
        {
            var userVM = await _userRepository.GetUserByNameAsync(id);
            var userDTO = _mapper.Map<UserDTO>(userVM);
            return userDTO;
        }

        public async Task<User> Insert(UserCreateDTO userDTO)
        {
            var clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/api/v1/users/");
            var login = new UserCreateFromJSON() { email = userDTO.EmailAddress, password = userDTO.Password };
            var postLogin = await clientLogin.PostAsJsonAsync("login", login);
            var token = postLogin.Content.ReadAsStringAsync().Result;
            var parseToken = JsonObject.Parse(token);
            var accessToken = parseToken["token"].ToString();
            var userVM = _mapper.Map<User>(userDTO);
            userVM.FirstName = userDTO.FirstName;
            userVM.LastName = userDTO.LastName;
            userVM.EmailAddress = userDTO.EmailAddress;
            userVM.Password = userDTO.Password;
            userVM.RepeatPassword = userDTO.RepeatPassword;
            userVM.Token = accessToken;
            userVM.CreateAt = DateTime.Now;
            _userRepository.Insert(userVM);
            _userRepository.Save();
            return userVM;
        }
    }
}
