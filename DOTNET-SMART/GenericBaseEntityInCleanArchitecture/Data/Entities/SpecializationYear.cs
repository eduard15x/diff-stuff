
using GenericBaseEntityInCleanArchitecture.Data.Common;

namespace GenericBaseEntityInCleanArchitecture.Data.Entities
{
    public class SpecializationYear : BaseEntity<int>
    {
        public int SpecializationId { get; set; }
        // TODO create validation
        // ! should be between 1-6
        // * 1 - master programs (ex)
        // * 2 - master programs (ex)
        // * 3 - license programs (mate-info science)
        // * 4 - license programs (computer science engineering)
        // * 6 - license programs (medicine)
        public int YearNumber { get; set; }

        // Navigation properties
        // Navigation properties
        public Specialization Specialization { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}