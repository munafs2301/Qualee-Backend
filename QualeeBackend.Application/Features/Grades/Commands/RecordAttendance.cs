using AutoMapper;
using MediatR;
using QualeeBackend.Application.DTOs;
using QualeeBackend.Domain.Entities;
using QualeeBackend.Domain.Interfaces;

namespace QualeeBackend.Application.Features.Grades.Commands
{
    public record RecordAttendance(
    Guid StudentId,
    Guid CourseId,
    DateTime Date,
    AttendanceStatus Status,
    string? Notes
    ) : IRequest<AttendanceDto>;

    public class RecordAttendanceCommandHandler: IRequestHandler<RecordAttendance, AttendanceDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RecordAttendanceCommandHandler(IUnitOfWork uow, IMapper mapper)
        => (_uow, _mapper) = (uow, mapper);

        public async Task<AttendanceDto> Handle(RecordAttendance req, CancellationToken ct)
        {
            var record = AttendanceRecord.Record(
                req.StudentId, req.CourseId, req.Date, req.Status, req.Notes);
            await _uow.Attendances.AddAsync(record, ct);
            await _uow.SaveChangesAsync(ct);
            return _mapper.Map<AttendanceDto>(record);
        }
    }
}
