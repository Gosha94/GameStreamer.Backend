using Microsoft.EntityFrameworkCore;
using GameStreamer.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStreamer.Infrastructure.Configurations;

internal class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {

        builder.ToTable("invitation", "game_streamer_backend");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.IncomerId)
            .HasColumnName("incomer_id")
            .IsRequired();

        builder.Property(p => p.RoomId)
            .HasColumnName("room_id")
            .IsRequired();

        builder.Property(p => p.Status)
            .HasConversion<string>()
            .HasColumnName("status")
            .IsRequired();

        builder.Property(p => p.CreatedOnUtc)
            .HasColumnName("created_on_utc")
            .IsRequired();

        builder.Property(p => p.ModifiedOnUtc)
            .HasColumnName("modified_on_utc");

    }
}