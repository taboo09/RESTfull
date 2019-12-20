using AutoMapper;
using REST.API.DTOs;
using REST.Domain.Entities;

namespace REST.API.Mapping
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffDto>();
        }
    }
}