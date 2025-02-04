
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class StudentExam : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public decimal? Grade { get; set; }
        public string Comments { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}