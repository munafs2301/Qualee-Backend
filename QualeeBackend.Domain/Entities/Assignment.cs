using QualeeBackend.Domain.Common;

namespace QualeeBackend.Domain.Entities
{
    public class Assignment : BaseEntity
    {
        public Guid CourseId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime DueDate { get; private set; }
        public decimal MaxScore { get; private set; }
        public bool IsPublished { get; private set; }
        public Course? Course { get; private set; }
        private Assignment() { }
        public static Assignment Create(Guid courseId, string title,
        string description, DateTime dueDate, decimal maxScore)
        => new Assignment
        {
            CourseId = courseId,
            Title = title,
            Description = description,
            DueDate = dueDate,
            MaxScore = maxScore,
        };
        public void Publish() { IsPublished = true; SetUpdatedAt(); }
    }
}
