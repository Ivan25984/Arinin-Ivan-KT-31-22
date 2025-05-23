using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.HasKey(p => p.AcademicDegreeId)
                .HasName($"pk_{TableName}_academic_degree_id");

            builder.Property(p => p.AcademicDegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("academic_degree_id")
                .HasComment("Идентификатор записи научной степени");

            builder.Property(p => p.AcademicDegreeName)
                .IsRequired()
                .HasColumnName("c_academic_degree_name")
                .HasMaxLength(100)
                .HasComment("Название научной степени");

            builder.ToTable(TableName);
        }
    }
}