using System;
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

        public virtual DbSet<Consultings> Consultings { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Designations> Designations { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<TblLabReport> TblLabReport { get; set; }
        public virtual DbSet<TblPatients> TblPatients { get; set; }
        public virtual DbSet<TblPaymentBill> TblPaymentBill { get; set; }
        public virtual DbSet<TblTest> TblTest { get; set; }
        public virtual DbSet<TbllAppointments> TbllAppointments { get; set; }
        public virtual DbSet<TbllMedicines> TbllMedicines { get; set; }
        public virtual DbSet<test> Tests { get; set; }
        public virtual DbSet<Users> Users { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ROHITDEEPAK\\SQLEXPRESS; Initial Catalog=DBClinic; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultings>(entity =>
            {
                entity.HasKey(e => e.ConsultingId)
                    .HasName("PK__Consulti__FA49E15E0CA525D6");

                entity.Property(e => e.ConsultingDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Consultings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Consultin__Docto__38996AB5");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Consultings)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Consultin__Patie__37A5467C");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__Departme__B2079BED3347F289");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Designations>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__Designat__BABD60DE3BD1745C");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__Doctors__2DC00EBF0918965E");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Doctors__Departm__6383C8BA");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patients__970EC366C08C9AA0");

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

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1A37F78FC9");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__Staffs__96D4AB1752A1A0B8");

                entity.Property(e => e.Experience).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Staffs__Departme__300424B4");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__Staffs__Designat__30F848ED");
            });

            modelBuilder.Entity<TblLabReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__TblLabRe__D5BD4805FBE1D1AE");

                entity.Property(e => e.ReportDate).HasColumnType("date");

                entity.Property(e => e.ReportNotes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TblLabRep__Docto__5EBF139D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TblLabRep__Patie__5CD6CB2B");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblLabReport)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__TblLabRep__Staff__5DCAEF64");
            });

            modelBuilder.Entity<TblPatients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__TblPatie__970EC3660146F3F8");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Contact).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TblPatien__Docto__6B24EA82");
            });

            modelBuilder.Entity<TblPaymentBill>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__TblPayme__11F2FC6A9096CFA4");

                entity.Property(e => e.BillDate).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblPaymentBill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TblPaymen__Patie__6E01572D");
            });

            modelBuilder.Entity<TblTest>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__TblTest__8CC331606D8361B6");

                entity.Property(e => e.NormalRange)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TestResult)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.TblTest)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK__TblTest__ReportI__619B8048");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblTest)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__TblTest__StaffId__628FA481");
            });

            modelBuilder.Entity<TbllAppointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__TbllAppo__8ECDFCC20DE874F4");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TbllAppointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TbllAppoi__Docto__71D1E811");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TbllAppointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TbllAppoi__Patie__70DDC3D8");
            });

            modelBuilder.Entity<TbllMedicines>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__TbllMedi__4F212890E6BE93A9");

                entity.Property(e => e.Dosage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TbllMedicines)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TbllMedic__Docto__75A278F5");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TbllMedicines)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__TbllMedic__Patie__74AE54BC");
            });

            modelBuilder.Entity<test>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__Tests__8CC3316046747876");

                entity.Property(e => e.NormalRange)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TestDate).HasColumnType("date");

                entity.Property(e => e.TestName)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TestResult)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Tests__DoctorId__02084FDA");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Tests__PatientId__00200768");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Tests__StaffId__01142BA1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4CA9AC7ED9");

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
                    .HasConstraintName("FK__Users__RoleId__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
