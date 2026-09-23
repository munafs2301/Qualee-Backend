using QualeeBackend.Domain.Common;

namespace QualeeBackend.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string EmployeeId { get; private set; } = string.Empty;
        public string Department { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
        public ICollection<Course> Courses { get; private set; } = new List<Course>();
        private Teacher() { }
        public static Teacher Create(string firstName, string lastName,
string email, string employeeId, string department)
=> new Teacher
{
    FirstName = firstName,
    LastName = lastName,
    Email = email,
    EmployeeId = employeeId,
    Department = department,
};
        public void Update(string firstName, string lastName,
        string email, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            SetUpdatedAt();
        }
        public string FullName => $"{FirstName} {LastName}";
    }
}
