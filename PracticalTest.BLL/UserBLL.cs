using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var userVM = await _userRepository.GetAllUserAsync();
            var userDTO = _mapper.Map<IEnumerable<UserDTO>>(userVM);
            return userDTO;
        }

        public async Task<UserDTO> GetUsersAsync(int id)
        {
            var userVM = await _userRepository.GetUserByNameAsync(id);
            var userDTO = _mapper.Map<UserDTO>(userVM);
            return userDTO;
        }

        public void Insert(UserCreateDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _userRepository.Insert(userVM);
            _userRepository.Save();
        }
    }
}
