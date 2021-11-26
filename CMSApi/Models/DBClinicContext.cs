﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMSApi.Models
{
    public partial class DBClinicContext : DbContext
    {
        public DBClinicContext()
        {
        }

        public DBClinicContext(DbContextOptions<DBClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Consultings> Consultings { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Designations> Designations { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Prescriptions> Prescriptions { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<TestBills> TestBills { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SHALLETMARY\\SQLEXPRESS; Initial Catalog=DBClinic; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__Bills__11F2FC6A5D96D6BA");

                entity.Property(e => e.ConsultingFee).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Consulting)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ConsultingId)
                    .HasConstraintName("FK__Bills__Consultin__619B8048");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Bills__MedicineI__628FA481");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Bills__PatientId__60A75C0F");
            });

            modelBuilder.Entity<Consultings>(entity =>
            {
                entity.HasKey(e => e.ConsultingId)
                    .HasName("PK__Consulti__FA49E15E0F7A81FC");

                entity.Property(e => e.ConsultingDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Consultings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Consultin__Docto__403A8C7D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Consultings)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Consultin__Patie__3F466844");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__Departme__B2079BED3727369D");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Designations>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__Designat__BABD60DE4FFFF644");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__Doctors__2DC00EBF308F4C74");

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__Medicine__4F2128906AE176FD");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicinesNavigation)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__Medicines__Presc__5DCAEF64");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patients__970EC3664BAB3379");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prescriptions>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__Prescrip__40130832DC5DFBCA");

                entity.Property(e => e.DoctorNotes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Medicines)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.HasOne(d => d.Consulting)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.ConsultingId)
                    .HasConstraintName("FK__Prescript__Consu__4BAC3F29");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Prescript__TestI__4CA06362");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Reports__D5BD480594765CEF");

                entity.Property(e => e.ReportDate).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Reports__Patient__656C112C");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ResultId)
                    .HasConstraintName("FK__Reports__ResultI__6754599E");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Reports__TestId__66603565");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => e.ResultId)
                    .HasName("PK__Results__9769020818678ED2");

                entity.Property(e => e.Result).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Results__TestId__4F7CD00D");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Role__8AFACE1A82D5EB10");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__Staffs__96D4AB174D20440F");

                entity.Property(e => e.Experience).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Staffs__Departme__33D4B598");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__Staffs__Designat__34C8D9D1");
            });

            modelBuilder.Entity<TestBills>(entity =>
            {
                entity.HasKey(e => e.TestBillId)
                    .HasName("PK__TestBill__5A2C509A9A108AE0");

                entity.Property(e => e.TestAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Consulting)
                    .WithMany(p => p.TestBills)
                    .HasForeignKey(d => d.ConsultingId)
                    .HasConstraintName("FK__TestBills__Consu__534D60F1");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestBills)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__TestBills__TestI__52593CB8");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__Tests__8CC331600E6481B1");

                entity.Property(e => e.TestDate).HasColumnType("date");

                entity.Property(e => e.TestNames)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.HasOne(d => d.Consulting)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.ConsultingId)
                    .HasConstraintName("FK__Tests__Consultin__440B1D61");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Tests__PatientId__4316F928");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C4CEC01ED");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleId__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
