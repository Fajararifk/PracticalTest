using AutoMapper;
using PracticalTest.BusinessObjects;
using PracticalTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Organizers, OrganizerDTO>();
            CreateMap<SportEvents, SportEventsDTO>();

            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<OrganizerDTO, Organizers>().ReverseMap();
            CreateMap<SportEventsDTO, SportEvents>().ReverseMap();
        }
    }
}
