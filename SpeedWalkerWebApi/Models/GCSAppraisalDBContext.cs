using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpeedWalkerWebApi.Models
{
    public partial class GCSAppraisalDBContext : DbContext
    {
        public GCSAppraisalDBContext()
        {
        }

        public GCSAppraisalDBContext(DbContextOptions<GCSAppraisalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppraisalPositionRating> AppraisalPositionRating { get; set; }
        public virtual DbSet<AppraisalRecords> AppraisalRecords { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<SalaryIncreaseRating> SalaryIncreaseRating { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=WINDOWS-FIKNDOP\\SQLEXPRESS;Database=GCSAppraisalDB;Trusted_Connection=True;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AppraisalPositionRating>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppraisalRecords>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalComment).IsUnicode(false);

                entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerAppraised).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManagerScore)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProblemSolving).HasColumnName("Problem_Solving");

                entity.Property(e => e.StaffId)
                    .HasColumnName("StaffID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorAppraised).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupervisorScore)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.BranchId)
                    .HasColumnName("BranchID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeoLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Levels)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.Rank)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalaryIncreaseRating>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExpectedScore).HasColumnName("expectedScore");

                entity.Property(e => e.PositionId)
                    .HasColumnName("positionID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.BranchId)
                    .HasColumnName("BranchID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cluster)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastAppraisal)
                    .HasColumnName("lastAppraisal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasColumnName("StaffID")
                    .IsUnicode(false);

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubDepartment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorId)
                    .HasColumnName("SupervisorID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Password)
                    .HasName("UQ__Users__87909B151F247B83")
                    .IsUnique();

                entity.HasIndex(e => e.StaffId)
                    .HasName("UQ__Users__96D4AAF65C3F2127")
                    .IsUnique();

                entity.HasIndex(e => e.StaffUniqueId)
                    .HasName("UQ__Users__A58642FE7CEC8DB9")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Users__1788CCADA96CBADA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalComments).IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsExternalUser).HasColumnName("isExternalUser");

                entity.Property(e => e.IsSpecialUser).HasColumnName("isSpecialUser");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUntil)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialUserId).HasColumnName("SpecialUserID");

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasColumnName("StaffID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffUniqueId).HasColumnName("staffUniqueID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
