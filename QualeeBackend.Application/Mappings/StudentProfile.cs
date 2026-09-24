using AutoMapper;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Entities;

namespace QualeeBackend.Application.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
