using QualeeBackend.Domain.Common;

namespace QualeeBackend.Domain.Entities
{
    public enum AttendanceStatus { Present, Absent, Late, Excused }
    public class AttendanceRecord : BaseEntity
    {
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public DateTime Date { get; private set; }
        public AttendanceStatus Status { get; private set; }
        public string? Notes { get; private set; }
        public Student? Student { get; private set; }
        public Course? Course { get; private set; }
        private AttendanceRecord() { }
        public static AttendanceRecord Record(Guid studentId, Guid courseId,
        DateTime date, AttendanceStatus status, string? notes = null)
        => new AttendanceRecord
        {
            StudentId = studentId,
            CourseId = courseId,
            Date = date,
            Status = status,
            Notes = notes,
        };
    }
}
