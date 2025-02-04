
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class Module : BaseEntity<int>
    {
        public int SpecializationYearId { get; set; }
        // TODO add validation
        // ! should have 2 if is divided in 2 semesters or 4 if follows the Bologna's system
        public int ModuleNumber { get; set; }
        public DateTime StartsFrom { get; set; }
        public DateTime EndsAt { get; set; }

        // Navigation properties
        public SpecializationYear SpecializationYear { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}