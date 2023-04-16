using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameStreamer.Domain.Entities;

namespace GameStreamer.Infrastructure.Storage.Configurations;

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

            nickNameBuilder.HasIndex(p => p.Value).IsUnique();
        });

    }
}