using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UsrsMVCApp.Models;

public partial class Stdnts5DbContext : DbContext
{
    public Stdnts5DbContext()
    {
    }

    public Stdnts5DbContext(DbContextOptions<Stdnts5DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {

            entity.HasIndex(e => e.UserId, "UQ_USERID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Emal, "IX_Users_EMAIL").IsUnique();

            entity.HasIndex(e => e.Lastname, "IX_Users_LASTNAME");

            entity.HasIndex(e => e.Username, "IX_Users_USERNAME").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Emal)
                .HasMaxLength(50)
                .HasColumnName("EMAL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Institution)
                .HasMaxLength(50)
                .HasColumnName("INSTITUTION");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .HasColumnName("USER_ROLE");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
