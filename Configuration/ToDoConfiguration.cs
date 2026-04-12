using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Models;

namespace TestingApp.Configuration
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            // Table name
            builder.ToTable(nameof(ToDo));

            // primary key
            builder.HasKey(u => u.Id);

            // Auto-increment(PostgreSQL)
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            // Columns
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(u => u.Status)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(u => u.CreatedDate)
                .IsRequired();

            builder.Property(u => u.UpdatedDate)
                .IsRequired(false);

        }
    }
}
