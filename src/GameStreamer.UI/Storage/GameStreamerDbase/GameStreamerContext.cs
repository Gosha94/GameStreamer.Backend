﻿using Microsoft.EntityFrameworkCore;
using GameStreamer.Storage.GameStreamerDbase.Mapping;

namespace GameStreamer.Storage.GameStreamerDbase
{
    public class GameStreamerContext : DbContext
    {

        public GameStreamerContext(DbContextOptions<GameStreamerContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        /// <summary>
        /// Настройка свойств моделей
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("game_streamer");

            modelBuilder.ApplyConfiguration(new PlayerEntityMap());
            modelBuilder.ApplyConfiguration(new RoomEntityMap());
        }

    }
}