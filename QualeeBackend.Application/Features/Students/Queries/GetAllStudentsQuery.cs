using AutoMapper;
using MediatR;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Interfaces;

namespace QualeeBackend.Application.Features.Students.Queries
{
    public record GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>;

    public class GetAllStudentsQueryHandler: IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllStudentsQueryHandler(IUnitOfWork uow, IMapper mapper)
        => (_uow, _mapper) = (uow, mapper);
        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken ct)
        {
            var students = await _uow.Students.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
