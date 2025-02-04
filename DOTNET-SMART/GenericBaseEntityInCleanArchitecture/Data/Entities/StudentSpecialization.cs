
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class StudentSpecialization : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public int SpecializationId { get; set; }
        public int EnrollmentYear { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Specialization Specialization { get; set; }
    }
}