namespace QualeeBackend.Application.DTOs
{
    public record CourseDto(
     Guid Id,
     string CourseCode,
     string Title,
     string Description,
     int Credits,
     Guid TeacherId,
     bool IsActive
     );

}
