using QualeeBackend.Domain.Common;
using QualeeBackend.Domain.Events;

namespace QualeeBackend.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public string StudentNumber { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
        public ICollection<Grade> Grades { get; private set; } = new List<Grade>();
        public ICollection<AttendanceRecord> Attendances { get; private set; } = new List<AttendanceRecord>();
        private Student() { }
        public static Student Create(string firstName, string lastName,
        string email, DateTime dateOfBirth, string studentNumber)
        {
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DateOfBirth = dateOfBirth,
                StudentNumber = studentNumber,
            };
            student.AddDomainEvent(new StudentCreatedEvent(student));
            return student;
        }
        public void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SetUpdatedAt();
        }
        public void Deactivate() { IsActive = false; SetUpdatedAt(); }
        public string FullName => $"{FirstName} {LastName}";
    }
}
