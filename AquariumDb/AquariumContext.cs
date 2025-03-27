using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AquariumDb;

public partial class AquariumContext : DbContext
{
    public AquariumContext(DbContextOptions<AquariumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthToken> AuthTokens { get; set; }

    public virtual DbSet<Decoration> Decorations { get; set; }

    public virtual DbSet<Fish> Fish { get; set; }

    public virtual DbSet<GameDatum> GameData { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthToken>(entity =>
        {
            entity.ToTable("auth_tokens");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("expires_at");
            entity.Property(e => e.Token)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Decoration>(entity =>
        {
            entity.ToTable("decorations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssetPath)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("asset_path");
            entity.Property(e => e.Color)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("color");
            entity.Property(e => e.DecorationType)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("decoration_type");
            entity.Property(e => e.PassiveIncome).HasColumnName("passive_income");
            entity.Property(e => e.PositionX)
                .HasColumnType("FLOAT")
                .HasColumnName("position_x");
            entity.Property(e => e.PositionY)
                .HasColumnType("FLOAT")
                .HasColumnName("position_y");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PurchasedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("purchased_at");
            entity.Property(e => e.Size)
                .HasColumnType("FLOAT")
                .HasColumnName("size");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Decorations).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.ToTable("fish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClickBonus).HasColumnName("click_bonus");
            entity.Property(e => e.Color)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("color");
            entity.Property(e => e.FishType)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("fish_type");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("name");
            entity.Property(e => e.PositionX)
                .HasColumnType("FLOAT")
                .HasColumnName("position_x");
            entity.Property(e => e.PositionY)
                .HasColumnType("FLOAT")
                .HasColumnName("position_y");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PurchasedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("purchased_at");
            entity.Property(e => e.Size)
                .HasColumnType("FLOAT")
                .HasColumnName("size");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Fish).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<GameDatum>(entity =>
        {
            entity.ToTable("game_data");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coins)
                .HasColumnType("BIGINT")
                .HasColumnName("coins");
            entity.Property(e => e.LastSaved)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_saved");
            entity.Property(e => e.TotalEarnedCoins)
                .HasColumnType("BIGINT")
                .HasColumnName("total_earned_coins");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.GameData).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "IX_users_username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.LastLogin)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_login");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
