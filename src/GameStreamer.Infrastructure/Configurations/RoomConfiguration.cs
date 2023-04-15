using GameStreamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStreamer.Infrastructure.Configurations;

internal class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("room", "game_streamer_backend");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.CreatedOnUtc).HasColumnName("created_on_utc").IsRequired();

        builder.HasMany(p => p.Roomies)
            .WithOne()
            .HasForeignKey(k => k.RoomId);

        builder.HasMany(p => p.Invitations)
            .WithOne()
            .HasForeignKey(k => k.IncomerId);

        builder.OwnsOne(p => p.RoomName);
        builder.OwnsOne(p => p.Creator);

    }
}