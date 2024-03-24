using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_PRN221.Model
{
    public partial class Project_PRN221Context : DbContext
    {
        public Project_PRN221Context()
        {
        }

        public Project_PRN221Context(DbContextOptions<Project_PRN221Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Timeslot> Timeslots { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId)
                    .ValueGeneratedNever()
                    .HasColumnName("Class_ID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Class_Name");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_ID");

                entity.Property(e => e.TimeslotId).HasColumnName("Timeslot_ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Class__Room_ID__2E1BDC42");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Class__Subject_I__2C3393D0");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Class__Teacher_I__2D27B809");

                entity.HasOne(d => d.Timeslot)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TimeslotId)
                    .HasConstraintName("FK__Class__Timeslot___2F10007B");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("Room_ID");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Room_Name");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("Subject_ID");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Subject_Name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .ValueGeneratedNever()
                    .HasColumnName("Teacher_ID");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Teacher_Name");
            });

            modelBuilder.Entity<Timeslot>(entity =>
            {
                entity.ToTable("Timeslot");

                entity.Property(e => e.TimeslotId)
                    .ValueGeneratedNever()
                    .HasColumnName("Timeslot_ID");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SlotNumber).HasColumnName("Slot_Number");

                entity.Property(e => e.SlotType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Slot_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
