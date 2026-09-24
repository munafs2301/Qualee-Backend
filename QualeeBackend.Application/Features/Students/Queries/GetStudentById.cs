using AutoMapper;
using MediatR;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Application.Features.Students.Queries
{
    public record GetStudentByIdQuery(Guid Id) : IRequest<StudentDto>;

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        => (_uow, _mapper) = (uow, mapper);

        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken ct)
        {
            var student = await _uow.Students.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Student {request.Id} not found.");
            return _mapper.Map<StudentDto>(student);
        }
    }
}
