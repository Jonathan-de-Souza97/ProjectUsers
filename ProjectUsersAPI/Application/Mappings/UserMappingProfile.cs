using Application.Commands;
using Application.DTOs;
using AutoMapper;
using Core.Entity;

namespace Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();

            CreateMap<User, AddUserCommand>()
                .ReverseMap();
        }
    }
}