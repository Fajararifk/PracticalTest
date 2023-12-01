using PracticalTest.BusinessObjects;
using PracticalTest.DTO.Create;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts.BLL
{
    public interface IUsersBLL
    {
        Task<JsonOrganizer> GetAllUsersAsync(int page, int perPage);
        Task<UserResponseDTO> GetUsersAsync(int Id);
        Task<UserResponseDTO> Insert(UserCreateAPIDTO organizerCreateDTO);
        Task<UserLoginResponse> Login(UserLogin organizerCreateDTO);
        Task<UserPutDTO> Edit(int id, UserPutDTO organizerCreateDTO);
        Task<UserPassword> Password(int id, UserPassword organizerCreateDTO);
        Task Delete(int id);
    }
}
