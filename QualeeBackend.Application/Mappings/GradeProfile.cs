using AutoMapper;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Entities;

namespace QualeeBackend.Application.Mappings
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeDto>();
        }
    }
}
