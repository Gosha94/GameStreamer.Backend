using GameStreamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStreamer.Infrastructure.Configurations;

internal class IncomerConfiguration : IEntityTypeConfiguration<Incomer>
{
    public void Configure(EntityTypeBuilder<Incomer> builder)
    {
        
    }
}