using QualeeBackend.Domain.Common;
using QualeeBackend.Domain.Entities;

namespace QualeeBackend.Domain.Events
{
    public record GradeAssignedEvent(Grade Grade) : IDomainEvent;
}
