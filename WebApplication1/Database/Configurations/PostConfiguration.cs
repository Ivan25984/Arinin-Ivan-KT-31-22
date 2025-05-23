using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Database.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private const string TableName = "cd_post";

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.PostId)
                .HasName($"pk_{TableName}_post_id");

            builder.Property(p => p.PostId)
                .ValueGeneratedOnAdd()
                .HasColumnName("post_id")
                .HasComment("Идентификатор записи должности");

            builder.Property(p => p.PostName)
                .IsRequired()
                .HasColumnName("c_post_name")
                .HasMaxLength(100)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}