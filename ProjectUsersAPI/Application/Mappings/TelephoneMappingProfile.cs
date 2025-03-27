using Application.DTOs;
using AutoMapper;
using Core.ValueObjects;

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