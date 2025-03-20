using Application.DTOs;
using AutoMapper;
using core.Entity;

namespace Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}