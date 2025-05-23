using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Database.Configurations
{
    public class WorkTimeConfiguration : IEntityTypeConfiguration<WorkTime>
    {
        private const string TableName = "cd_work_time";

        public void Configure(EntityTypeBuilder<WorkTime> builder)
        {
            builder.HasKey(p => p.WorkTimeId)
                .HasName($"pk_{TableName}_work_time_id");

            builder.Property(p => p.WorkTimeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("work_time_id")
                .HasComment("Идентификатор записи рабочего времени");

            builder.Property(p => p.WorkTimeHours)
                .IsRequired()
                .HasColumnName("c_work_time_hours")
                .HasColumnType("INT")
                .HasComment("Количество часов");

            builder.Property(p => p.ProfessorId)
                .IsRequired()
                .HasColumnName("f_professor_id")
                .HasComment("ID профессора");

            builder.HasOne(p => p.Professor)
                .WithMany() // Убедитесь, что вы добавили соответствующее свойство в Professor, если это необходимо
                .HasForeignKey(p => p.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("f_department_id")
                .HasComment("ID кафедры");

            builder.HasOne(p => p.Department)
                .WithMany() // Убедитесь, что вы добавили соответствующее свойство в Cafedre, если это необходимо
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.DisciplineId)
                .IsRequired()
                .HasColumnName("f_discipline_id")
                .HasComment("ID дисциплины");

            builder.HasOne(p => p.Discipline)
                .WithMany() // Убедитесь, что вы добавили соответствующее свойство в Discipline, если это необходимо
                .HasForeignKey(p => p.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.ProfessorId, $"idx+{TableName}_fk_f_professor_id");
            builder.HasIndex(p => p.DepartmentId, $"idx+{TableName}_fk_f_department_id");
            builder.HasIndex(p => p.DisciplineId, $"idx+{TableName}_fk_f_discipline_id");

            builder.ToTable(TableName);
        }
    }
}
