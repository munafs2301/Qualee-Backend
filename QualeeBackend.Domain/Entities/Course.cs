using QualeeBackend.Domain.Common;
using QualeeBackend.Domain.Events;

namespace QualeeBackend.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string CourseCode { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Credits { get; private set; }
        public Guid TeacherId { get; private set; }
        public bool IsActive { get; private set; } = true;
        public Teacher? Teacher { get; private set; }
        public ICollection<Grade> Grades { get; private set; } = new List<Grade>();
        public ICollection<Assignment> Assignments { get; private set; } = new List<Assignment>();
        private Course() { }
        public static Course Create(string courseCode, string title,
        string description, int credits, Guid teacherId)
        {
            var course = new Course
            {
                CourseCode = courseCode,
                Title = title,
                Description = description,
                Credits = credits,
                TeacherId = teacherId,
            };
            course.AddDomainEvent(new CourseCreatedEvent(course));
            return course;
        }
        public void Update(string title, string description, int credits)
        {
            Title = title;
            Description = description;
            Credits = credits;
            SetUpdatedAt();
        }
    }
}
