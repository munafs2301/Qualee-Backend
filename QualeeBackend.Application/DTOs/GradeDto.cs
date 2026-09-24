namespace QualeeBackend.Application.DTOs
{
    public record GradeDto(
      Guid Id,
      Guid StudentId,
      Guid CourseId,
      decimal Score,
      string LetterGrade,
      string Semester,
      int Year,
      string? Comments
      );
}
