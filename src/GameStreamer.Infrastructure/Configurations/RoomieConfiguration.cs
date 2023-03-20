using GameStreamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStreamer.Infrastructure.Configurations;

internal class RoomieConfiguration : IEntityTypeConfiguration<Roomie>
{
    public void Configure(EntityTypeBuilder<Roomie> builder)
    {
        
    }
}