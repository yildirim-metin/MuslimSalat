using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Configs;

public partial class MuslimSalatContext : DbContext
{
    public MuslimSalatContext(DbContextOptions<MuslimSalatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Mission> Missions { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<Prayer> Prayers { get; set; }

    public virtual DbSet<PrayerReminder> PrayerReminders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Latitude).HasMaxLength(50);
            entity.Property(e => e.Locality).HasMaxLength(250);
            entity.Property(e => e.Longitude).HasMaxLength(50);
        });

        modelBuilder.Entity<Mission>(entity =>
        {
            entity.ToTable("Mission");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Level).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.ToTable("Parameter");

            entity.HasIndex(e => e.IdUser, "UQ_IdUser").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdUser).ValueGeneratedOnAdd();
            entity.Property(e => e.PrayerReminderMinutes).HasDefaultValue((byte)15);

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Parameter)
                .HasForeignKey<Parameter>(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parameter_User");
        });

        modelBuilder.Entity<Prayer>(entity =>
        {
            entity.ToTable("Prayer");

            entity.Property(e => e.Datetime).HasPrecision(0);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<PrayerReminder>(entity =>
        {
            entity.ToTable("PrayerReminder");

            entity.Property(e => e.Datetime).HasPrecision(0);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ_Username").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("User");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdAddress)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_Address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
