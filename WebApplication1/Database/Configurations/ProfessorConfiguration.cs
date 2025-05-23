using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Database.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        private const string TableName = "cd_professor";

        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.ProfessorId)
                .HasName($"pk_{TableName}_professor_id");

            builder.Property(p => p.ProfessorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("professor_id")
                .HasComment("Идентификатор записи профессора");

            builder.Property(p => p.ProfessorFirstName)
                .IsRequired()
                .HasColumnName("c_professor_first_name")
                .HasMaxLength(100)
                .HasComment("Имя профессора");

            builder.Property(p => p.ProfessorLastName)
                .IsRequired()
                .HasColumnName("c_professor_last_name")
                .HasMaxLength(100)
                .HasComment("Фамилия профессора");

            builder.Property(p => p.ProfessorMiddleName)
                .IsRequired()
                .HasColumnName("c_professor_middle_name")
                .HasMaxLength(100)
                .HasComment("Отчество профессора");

            builder.Property(p => p.ProfessorTitle)
                .IsRequired()
                .HasColumnName("c_professor_title")
                .HasMaxLength(100)
                .HasComment("Должность профессора");

            builder.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("f_department_id")
                .HasComment("ID кафедры");

            builder.HasOne(p => p.Department)
                .WithMany(c => c.Professors) // Обязательно: это свойство должно быть в классе Department
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName);
        }
    }
}