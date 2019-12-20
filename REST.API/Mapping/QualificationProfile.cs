using AutoMapper;
using REST.API.DTOs;
using REST.Domain.Entities;

namespace REST.API.Mapping
{
    public class QualificationProfile : Profile
    {
        public QualificationProfile()
        {
            CreateMap<Qualification, QualificationDto>();
        }
    }
}