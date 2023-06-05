using PracticalTest.DTO;
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
        Task<UserDTO> GetUsersAsync(string name);
        void Insert(UserDTO userDTO);
        void Edit(UserDTO userDTO);
        void Delete(UserDTO userDTO);
    }
}
