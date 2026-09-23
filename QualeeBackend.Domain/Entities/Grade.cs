using QualeeBackend.Domain.Common;
using QualeeBackend.Domain.Events;

namespace QualeeBackend.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public decimal Score { get; private set; }
        public string LetterGrade { get; private set; } = string.Empty;
        public string Semester { get; private set; } = string.Empty;
        public int Year { get; private set; }
        public string? Comments { get; private set; }
        public Student? Student { get; private set; }
        public Course? Course { get; private set; }
        private Grade() { }
        public static Grade Assign(Guid studentId, Guid courseId,
        decimal score, string semester, int year, string? comments = null)
        {
            var grade = new Grade
            {
                StudentId = studentId,
                CourseId = courseId,
                Score = score,
                LetterGrade = CalculateLetterGrade(score),
                Semester = semester,
                Year = year,
                Comments = comments,
            };
            grade.AddDomainEvent(new GradeAssignedEvent(grade));
            return grade;
        }
        private static string CalculateLetterGrade(decimal score) => score switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
    }
}
