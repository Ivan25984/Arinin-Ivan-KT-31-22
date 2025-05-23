using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.Property(p => p.DepartmentCreationDate)
                .IsRequired()
                .HasColumnName("c_department_creation_date")
                .HasColumnType("timestamp")
                .HasComment("Дата основания кафедры");

            builder.Property(p => p.DepartmentMainProfessor)
                .IsRequired()
                .HasColumnName("c_department_main_professor")
                .HasMaxLength(100)
                .HasComment("Старший преподаватель кафедры");

            builder.Property(p => p.DepartmentProfessorsAmount)
                .IsRequired()
                .HasColumnName("c_department_professors_amount")
                .HasColumnType("INT")
                .HasComment("Количество профессоров");

            builder.ToTable(TableName);
        }
    }
}