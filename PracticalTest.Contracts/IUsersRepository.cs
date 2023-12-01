using PracticalTest.BusinessObjects;
using PracticalTest.DTO.Create;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Contracts
{
    public interface IUsersRepository
    {
        Task<JsonOrganizer> GetAllUsersAsync(int page, int perPage);
        Task<UserResponseDTO> GetUsersByIdAsync(int id);
        Task<UserResponseDTO> InsertAsync(UserCreateAPIDTO organizer);
        Task<UserLoginResponse> LoginAsync(UserLogin organizer);
        Task<UserPutDTO> EditAsync(int id, UserPutDTO organizer);
        Task<UserPassword> PasswordAsync(int id, UserPassword userPassword);
        Task DeleteAsync(int id);
    }
}
