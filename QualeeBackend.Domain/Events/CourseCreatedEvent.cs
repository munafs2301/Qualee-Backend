using QualeeBackend.Domain.Common;
using QualeeBackend.Domain.Entities;

namespace QualeeBackend.Domain.Events
{
    public record CourseCreatedEvent(Course Course) : IDomainEvent;
}
