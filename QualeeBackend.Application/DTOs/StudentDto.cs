namespace QualeeBackend.Application.DTOs
{
    public record StudentDto(
     Guid Id,
     string FirstName,
     string LastName,
     string Email,
     DateTime DateOfBirth,
     string StudentNumber,
     bool IsActive,
     DateTime CreatedAt
     );
}
