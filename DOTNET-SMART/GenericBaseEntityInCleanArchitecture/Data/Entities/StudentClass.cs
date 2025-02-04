
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class StudentClass : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int ModuleId { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Class Class { get; set; }
        public Module Module { get; set; }

    }
}