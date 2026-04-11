using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Models;

namespace TestingApp.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table name
            builder.ToTable(nameof(Employee));

            // primary key
            builder.HasKey(u => u.Id);

            // Auto-increment(PostgreSQL)
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            // Columns
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.MobileNo)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(u => u.Department)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(u => u.UnitId)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.Property(u => u.Address1)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(u => u.Address2)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(u => u.IsActive)
                .IsRequired(true)
                .HasDefaultValue(false);

            builder.Property(u => u.LastUpdated)
                .HasDefaultValue(new DateTime())
                .IsRequired();
        }
    }
}
