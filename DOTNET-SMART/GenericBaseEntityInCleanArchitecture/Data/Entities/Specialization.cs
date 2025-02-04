
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class Specialization : BaseEntity<int>
    {
        public string Name { get; set; }
        public int TotalYears { get; set; }

        // Navigation properties
        public ICollection<SpecializationYear> SpecializationYears { get; set; }
        public ICollection<StudentSpecialization> StudentSpecializations { get; set; }
    }
}