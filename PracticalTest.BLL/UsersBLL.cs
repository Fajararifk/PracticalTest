using AutoMapper;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;

namespace PracticalTest.BLL
{
    public class UsersBLL : IUsersBLL
    {
        private readonly IUsersRepository _organizerRepository;
        private readonly IMapper _mapper;
        public UsersBLL(IUsersRepository organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }
        public Task Delete(int id)
        {
            var delete = _organizerRepository.DeleteAsync(id);
            return delete;
        }

        public Task<UserPutDTO> Edit(int id, UserPutDTO organizerCreateDTO)
        {
            var edit = _organizerRepository.EditAsync(id, organizerCreateDTO);
            return edit;
        }

        public Task<UserPassword> Password(int id, UserPassword organizerCreateDTO)
        {
            var edit = _organizerRepository.PasswordAsync(id, organizerCreateDTO);
            return edit;
        }
        public async Task<JsonOrganizer> GetAllUsersAsync(int page, int perPage)
        {
            var orgVM = await _organizerRepository.GetAllUsersAsync(page, perPage);
            return orgVM;
        }

        public async Task<UserResponseDTO> GetUsersAsync(int Id)
        {
            var orgVM = await _organizerRepository.GetUsersByIdAsync(Id);
            return orgVM;
        }

        public Task<UserResponseDTO> Insert(UserCreateAPIDTO organizerCreateDTO)
        {
            var insert = _organizerRepository.InsertAsync(organizerCreateDTO);
            return insert;
        }
        public async Task<UserLoginResponse> Login(UserLogin organizerCreateDTO)
        {
            var insert = await _organizerRepository.LoginAsync(organizerCreateDTO);
            return insert;
        }
    }
}
