using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Application.DTOs
{
    public record AttendanceDto(
        Guid Id,
        Guid StudentId,
        Guid CourseId,
        DateTime Date,
        string Status,
        string? Notes
    );
}
