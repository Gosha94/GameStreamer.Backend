﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameStreamer.Domain.Entities;

namespace GameStreamer.Infrastructure.Storage.Configurations;

internal class RoomieConfiguration : IEntityTypeConfiguration<Roomie>
{
    public void Configure(EntityTypeBuilder<Roomie> builder)
    {
        builder.ToTable("roomie", "game_streamer_backend");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.RoomId)
            .HasColumnName("room_id")
            .IsRequired();

        builder.Property(p => p.IncomerId)
            .HasColumnName("incomer_id")
            .IsRequired();

        builder.Property(p => p.CreatedOnUtc)
            .HasColumnName("created_on_utc")
            .IsRequired();
    }
}