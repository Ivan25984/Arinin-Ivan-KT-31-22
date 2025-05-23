using WebApplication1.Database.Configurations;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Database
{
    public class StudentDbContext : DbContext
    {
        // Добавляем таблицы
        public DbSet<Department> Departments { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Professor> Professors { get; set; }
        DbSet<AcademicDegree> AcademicDegrees { get; set; }
        DbSet<Post> Posts { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new WorkTimeConfiguration());
        }


        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }
}