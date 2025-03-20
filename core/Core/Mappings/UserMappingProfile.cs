using AutoMapper;
using core.DTOs;
using core.Entity;

namespace core.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AddUserDTO, User>()
                .ReverseMap();
        }
    }
}