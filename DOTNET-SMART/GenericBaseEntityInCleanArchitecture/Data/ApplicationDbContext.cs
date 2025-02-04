using GenericBaseEntityInCleanArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericBaseEntityInCleanArchitecture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SpecializationYear> SpecializationYears { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSpecialization> StudentSpecializations { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}