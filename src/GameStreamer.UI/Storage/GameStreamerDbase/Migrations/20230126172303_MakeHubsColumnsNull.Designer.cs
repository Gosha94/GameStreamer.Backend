﻿// <auto-generated />
using System;
using GameStreamer.Storage.GameStreamerDbase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameStreamer.Storage.GameStreamerDbase.Migrations
{
    [DbContext(typeof(GameStreamerContext))]
    [Migration("20230126172303_MakeHubsColumnsNull")]
    partial class MakeHubsColumnsNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("game_streamer")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameStreamer.Storage.GameStreamerDbase.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChatHubId")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("chat_hub_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("GameHubId")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("game_hub_id");

                    b.Property<bool>("IsRandomGameMode")
                        .HasColumnType("boolean")
                        .HasColumnName("is_random_game_mode");

                    b.Property<bool>("IsReadyForGame")
                        .HasColumnType("boolean")
                        .HasColumnName("is_ready_for_game");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("nickname");

                    b.Property<Guid>("PlayerGuid")
                        .HasColumnType("UUID")
                        .HasColumnName("player_guid");

                    b.Property<string>("RoomHubId")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("room_hub_id");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("connected_players", "game_streamer");
                });

            modelBuilder.Entity("GameStreamer.Storage.GameStreamerDbase.Entities.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("HubGroupId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("hub_group_id");

                    b.Property<Guid>("RoomGuid")
                        .HasColumnType("UUID")
                        .HasColumnName("room_guid");

                    b.HasKey("Id");

                    b.ToTable("game_rooms", "game_streamer");
                });

            modelBuilder.Entity("GameStreamer.Storage.GameStreamerDbase.Entities.PlayerEntity", b =>
                {
                    b.HasOne("GameStreamer.Storage.GameStreamerDbase.Entities.RoomEntity", "Room")
                        .WithMany("JoinedPlayers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("GameStreamer.Storage.GameStreamerDbase.Entities.RoomEntity", b =>
                {
                    b.Navigation("JoinedPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
