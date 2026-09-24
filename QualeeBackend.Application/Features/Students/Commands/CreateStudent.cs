using AutoMapper;
using FluentValidation;
using MediatR;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Application.Features.Students.Commands
{
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDto>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;
            public CreateStudentCommandHandler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }
            public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken ct)
            {
                // Guard: duplicate email
                var existing = await _uow.Students.GetByEmailAsync(request.Email, ct);

                if (existing is not null)
                    throw new InvalidOperationException(
                    $"A student with email '{request.Email}' already exists.");

                var student = Student.Create(
                request.FirstName, request.LastName, request.Email,
                request.DateOfBirth, request.StudentNumber);

                await _uow.Students.AddAsync(student, ct);
                await _uow.SaveChangesAsync(ct);

                return _mapper.Map<StudentDto>(student);
            }
        }

    public record CreateStudentCommand(
       string FirstName,
       string LastName,
       string Email,
       DateTime DateOfBirth,
       string StudentNumber
       ) : IRequest<StudentDto>;
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100);
            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100);
            RuleFor(x => x.Email)
            .NotEmpty().EmailAddress()
            .WithMessage("A valid email address is required.");
            RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.UtcNow.AddYears(-5))
            .WithMessage("Student must be at least 5 years old.");
            RuleFor(x => x.StudentNumber)
            .NotEmpty().MaximumLength(20);
        }
    }
}
