using CleanRobust.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanRobust.Infrastructure.Configuration;

public class EventStoreConfig : IEntityTypeConfiguration<EventStore>
{
    public void Configure(EntityTypeBuilder<EventStore> builder)
    {
        builder.Property(p => p.AggregateId)
            .IsRequired();

        builder.Property(p => p.MessageType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Data)
            .IsRequired();

        builder.Property(p => p.CreatedDateTime)
            .IsRequired();
    }
}
