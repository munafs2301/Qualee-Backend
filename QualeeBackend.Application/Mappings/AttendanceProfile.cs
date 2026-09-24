using AutoMapper;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Application.Mappings
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<AttendanceRecord, AttendanceDto>()
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
        }
    }
}
