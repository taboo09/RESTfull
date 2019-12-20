using AutoMapper;
using REST.API.DTOs;
using REST.Domain.Entities;

namespace REST.API.Mapping
{
    public class CareHomeProfile : Profile
    {
        public CareHomeProfile()
        {
            CreateMap<CareHome, CareHomeDto>();
        }
    }
}