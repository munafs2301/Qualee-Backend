using MediatR;
using Microsoft.Extensions.Logging;
using QualeeBackend.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Handlers
{
    public class StudentCreatedEventHandler : INotificationHandler<StudentCreatedEvent>
    {
        private readonly ILogger<StudentCreatedEventHandler> _logger;
        public StudentCreatedEventHandler(
        ILogger<StudentCreatedEventHandler> logger) => _logger = logger;
        public Task Handle(StudentCreatedEvent notification, CancellationToken ct)
        {
            _logger.LogInformation(
            "Domain Event: Student created – {StudentId} ({Email})",
            notification.Student.Id,
            notification.Student.Email);
            return Task.CompletedTask;
        }
    }
}
