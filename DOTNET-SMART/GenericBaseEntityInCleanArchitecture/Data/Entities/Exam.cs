
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class Exam : BaseEntity<int>
    {
        public int ClassId { get; set; }
        public int ModuleId { get; set; }
        public DateTime ExamDate { get; set; }
        public string? ImageUrl { get; set; }

        // Navigation properties
        public Class Class { get; set; }
        public Module Module { get; set; }
    }
}