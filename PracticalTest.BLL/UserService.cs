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
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public void Delete(UserDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _repositoryManager.UserRepository.Remove(userVM);
            _repositoryManager.Save();
        }

        public void Edit(UserDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _repositoryManager.UserRepository.Edit(userVM);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var userVM = await _repositoryManager.UserRepository.GetAllUser();
            var userDTO = _mapper.Map<IEnumerable<UserDTO>>(userVM);
            return userDTO;
        }

        public async Task<UserDTO> GetUsers(string name)
        {
            var userVM = await _repositoryManager.UserRepository.GetUserByName(name);
            var userDTO = _mapper.Map<UserDTO>(userVM);
            return userDTO;
        }

        public void Insert(UserDTO userDTO)
        {
            var userVM = _mapper.Map<User>(userDTO);
            _repositoryManager.UserRepository.Insert(userVM);
            _repositoryManager.Save();
        }
    }
}
