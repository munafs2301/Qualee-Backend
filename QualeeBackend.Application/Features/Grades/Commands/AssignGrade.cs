using AutoMapper;
using FluentValidation;
using MediatR;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;

namespace QualeeBackend.Application.Features.Grades.Commands
{
    public record AssignGradeCommand(
     Guid StudentId,
     Guid CourseId,
     decimal Score,
     string Semester,
     int Year,
     string? Comments
     ) : IRequest<GradeDto>;

    public class AssignGradeCommandHandler : IRequestHandler<AssignGradeCommand, GradeDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AssignGradeCommandHandler(IUnitOfWork uow, IMapper mapper)
        => (_uow, _mapper) = (uow, mapper);
        public async Task<GradeDto> Handle(AssignGradeCommand req, CancellationToken ct)
        {
            var student = await _uow.Students.GetByIdAsync(req.StudentId, ct)
            ?? throw new KeyNotFoundException($"Student {req.StudentId} not found.");

            var course = await _uow.Courses.GetByIdAsync(req.CourseId, ct)
            ?? throw new KeyNotFoundException($"Course {req.CourseId} not found.");

            var grade = Grade.Assign(req.StudentId, req.CourseId,
            req.Score, req.Semester, req.Year, req.Comments);

            await _uow.Grades.AddAsync(grade, ct);
            await _uow.SaveChangesAsync(ct);

            return _mapper.Map<GradeDto>(grade);
        }
    }

    public class AssignGradeValidator : AbstractValidator<AssignGradeCommand>
    {
        public AssignGradeValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty();
            RuleFor(x => x.Score)
            .InclusiveBetween(0, 100)
            .WithMessage("Score must be between 0 and 100.");
            RuleFor(x => x.Semester)
            .NotEmpty().MaximumLength(20);
            RuleFor(x => x.Year)
            .GreaterThan(2000).LessThanOrEqualTo(DateTime.UtcNow.Year + 1);
        }
    }
}
