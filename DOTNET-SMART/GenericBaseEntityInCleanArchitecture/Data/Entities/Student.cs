
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class Student : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        // Navigation properties
        public ICollection<StudentSpecialization> StudentSpecializations { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}