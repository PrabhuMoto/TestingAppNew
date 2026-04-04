using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Models;

namespace TestingApp.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table name
        builder.ToTable(nameof(User));

        // primary key
        builder.HasKey(u => u.Id);

        // Auto-increment(PostgreSQL)
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        // Columns
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Role)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(u => u.CreatedDate)
            .HasDefaultValue(new DateTime())
            .IsRequired();
    }
}