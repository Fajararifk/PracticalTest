using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.Service;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
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

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var userVM = await _userRepository.GetAllUser();
            var userDTO = _mapper.Map<IEnumerable<UserDTO>>(userVM);
            return userDTO;
        }

        public async Task<UserDTO> GetUsers(string name)
        {
            var userVM = await _userRepository.GetUserByName(name);
            var userDTO = _mapper.Map<UserDTO>(userVM);
            return userDTO;
        }

        public void Insert(UserDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _userRepository.Insert(userVM);
            _userRepository.Save();
        }
    }
}
