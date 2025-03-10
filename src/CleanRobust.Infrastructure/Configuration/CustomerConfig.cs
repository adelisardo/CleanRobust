using CleanRobust.Domain.Entities.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanRobust.Infrastructure.Configuration;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.Firstname)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Lastname)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.DateOfBirth)
            .IsRequired();

        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.BankAccountNumber)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();
    }
}
