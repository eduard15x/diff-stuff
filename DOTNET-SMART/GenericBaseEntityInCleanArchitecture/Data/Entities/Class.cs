
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class Class : BaseEntity<int>
    {
        public int SpecializationId { get; set; }
        public int SpecializationYearId { get; set; }
        public int ModuleId { get; set; }
        public string ClassName { get; set; }
        public int Credits { get; set; }
        public bool IsMandatory { get; set; } = true;

        // Navigation properties
        public Specialization Specialization { get; set; }
        public SpecializationYear SpecializationYear { get; set; }
        public Module Module { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}