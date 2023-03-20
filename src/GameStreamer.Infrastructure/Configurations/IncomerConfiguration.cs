using Microsoft.EntityFrameworkCore;
using GameStreamer.Domain.Entities.Incomers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStreamer.Infrastructure.Configurations;

internal class IncomerConfiguration : IEntityTypeConfiguration<Incomer>
{
    public void Configure(EntityTypeBuilder<Incomer> builder)
    {
        builder.ToTable("incomer", "game_streamer_backend");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.OwnsOne(p => p.NickName, nickNameBuilder =>
        {
            nickNameBuilder.Property(p => p.Value)
                .HasMaxLength(30)
                .HasColumnName("nick_name")
                .IsRequired();
        });

        builder.HasIndex(p => p.NickName)
            .IsUnique();
    }
}