using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
using PracticalTest.DTO.Create;

namespace PracticalTest.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserCreateDTO>();
            CreateMap<Organizers, OrganizerDTO>();
            CreateMap<Organizers, OrganizerCreateDTO>();
            CreateMap<SportEvents, SportEventsDTO>();

            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<OrganizerDTO, Organizers>().ReverseMap();
            CreateMap<OrganizerCreateDTO, Organizers>().ReverseMap();
            CreateMap<SportEventsDTO, SportEvents>().ReverseMap();
            CreateMap<SportEventsCreateAPIDTO, SportEvents>().ReverseMap();
        }
    }
}
