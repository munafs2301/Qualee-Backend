using AutoMapper;
using MediatR;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Interfaces;

namespace QualeeBackend.Application.Features.Students.Commands
{
    public record UpdateStudentCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string Email) : IRequest<StudentDto>;

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UpdateStudentCommandHandler(IUnitOfWork uow, IMapper mapper)
        => (_uow, _mapper) = (uow, mapper);
        public async Task<StudentDto> Handle(
        UpdateStudentCommand request, CancellationToken ct)
        {
            var student = await _uow.Students.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Student {request.Id} not found.");
            student.Update(request.FirstName, request.LastName, request.Email);
            _uow.Students.Update(student);
            await _uow.SaveChangesAsync(ct);
            return _mapper.Map<StudentDto>(student);
        }
    }
}
