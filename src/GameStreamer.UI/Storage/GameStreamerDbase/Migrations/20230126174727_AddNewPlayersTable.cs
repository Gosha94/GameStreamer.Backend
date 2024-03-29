﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameStreamer.Storage.GameStreamerDbase.Migrations
{
    public partial class AddNewPlayersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "connected_players",
                schema: "game_streamer");

            migrationBuilder.CreateTable(
                name: "new_players_without_room",
                schema: "game_streamer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nickname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_new_players_without_room", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "players_in_rooms",
                schema: "game_streamer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    nickname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    chat_hub_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    game_hub_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    room_hub_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    player_guid = table.Column<Guid>(type: "UUID", nullable: false),
                    is_ready_for_game = table.Column<bool>(type: "boolean", nullable: false),
                    is_random_game_mode = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players_in_rooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_players_in_rooms_game_rooms_room_id",
                        column: x => x.room_id,
                        principalSchema: "game_streamer",
                        principalTable: "game_rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_in_rooms_room_id",
                schema: "game_streamer",
                table: "players_in_rooms",
                column: "room_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "new_players_without_room",
                schema: "game_streamer");

            migrationBuilder.DropTable(
                name: "players_in_rooms",
                schema: "game_streamer");

            migrationBuilder.CreateTable(
                name: "connected_players",
                schema: "game_streamer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    chat_hub_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    game_hub_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    is_random_game_mode = table.Column<bool>(type: "boolean", nullable: false),
                    is_ready_for_game = table.Column<bool>(type: "boolean", nullable: false),
                    nickname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    player_guid = table.Column<Guid>(type: "UUID", nullable: false),
                    room_hub_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connected_players", x => x.id);
                    table.ForeignKey(
                        name: "FK_connected_players_game_rooms_room_id",
                        column: x => x.room_id,
                        principalSchema: "game_streamer",
                        principalTable: "game_rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_connected_players_room_id",
                schema: "game_streamer",
                table: "connected_players",
                column: "room_id");
        }
    }
}
