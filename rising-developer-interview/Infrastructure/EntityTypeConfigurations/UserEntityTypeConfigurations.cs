using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rising_developer_interview.Entities;

namespace rising_developer_interview.Infrastructure.EntityTypeConfigurations;

public class UserEntityTypeConfigurations
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(u => u.Email)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(u => u.DiagnosticLevel)
            .IsRequired();

        builder.Property(u => u.CurrentLevel)
            .IsRequired();

        builder.Property(u => u.FirstMessageTimestamp)
            .IsRequired();

        builder.Property(u => u.LastMessageTimestamp)
            .IsRequired();

        builder.Property(u => u.MessageIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
}