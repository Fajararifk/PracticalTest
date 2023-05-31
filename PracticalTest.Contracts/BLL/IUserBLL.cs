using PracticalTest.DTO;
using PracticalTest.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface IUserBLL
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO>GetUsersAsync(int id);
        void Insert(UserCreateDTO userDTO);
        void Edit(UserDTO userDTO);
        void Delete(UserDTO userDTO);
    }
}
