using GameStreamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStreamer.Infrastructure.Configurations;

internal class IncomerConfiguration : IEntityTypeConfiguration<Incomer>
{
    public void Configure(EntityTypeBuilder<Incomer> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).HasConversion();
    }
}