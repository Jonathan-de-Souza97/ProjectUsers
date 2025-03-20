using Application.DTOs;
using core.Entity;
using AutoMapper;
using core.ValueObjects;

namespace Application.Mappings
{
    public class TelephoneMeppingProfile : Profile
    {
        public TelephoneMeppingProfile()
        {
            CreateMap<TelephoneDTO, Telephone>()
                .ReverseMap();
        }
    }
}