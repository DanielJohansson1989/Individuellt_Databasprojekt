using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Individuellt_Databasprojekt.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdministrator> TblAdministrators { get; set; }

    public virtual DbSet<TblClass> TblClasses { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblGrade> TblGrades { get; set; }

    public virtual DbSet<TblJanitor> TblJanitors { get; set; }

    public virtual DbSet<TblPrincipal> TblPrincipals { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblSubject> TblSubjects { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source = LAPTOP-4AAOB4IN;Initial Catalog = Labb_3_DB;Integrated Security = true;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdministrator>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__tblAdmin__719FE4E86D90A2FA");

            entity.ToTable("tblAdministrator");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AdminFName");
            entity.Property(e => e.AdminLname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("AdminLName");
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.StaffId)
                .HasDefaultValue(2)
                .HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblAdministrators)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAdministrator_tblStaff");
        });

        modelBuilder.Entity<TblClass>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__tblClass__CB1927A038AC265B");

            entity.ToTable("tblClass");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__tblCours__C92D7187BD507B1A");

            entity.ToTable("tblCourse");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Grade).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_tblCourse_tblGrade");

            entity.HasOne(d => d.Student).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCourse_tblStudent");

            entity.HasOne(d => d.Subject).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCourse_tblSubject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_tblCourse_tblTeacher");
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__tblDepar__B2079BED518C1687");

            entity.ToTable("tblDepartment");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblGrade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__tblGrade__54F87A373EB7AF30");

            entity.ToTable("tblGrade");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.GradeSymbol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblJanitor>(entity =>
        {
            entity.HasKey(e => e.JanitorId).HasName("PK__tblJanit__C46FE15624C97B26");

            entity.ToTable("tblJanitor");

            entity.Property(e => e.JanitorId).HasColumnName("JanitorID");
            entity.Property(e => e.JanitorFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JanitorFName");
            entity.Property(e => e.JanitorLname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("JanitorLName");
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.StaffId)
                .HasDefaultValue(4)
                .HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblJanitors)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblJanitor_tblStaff");
        });

        modelBuilder.Entity<TblPrincipal>(entity =>
        {
            entity.HasKey(e => e.PrincipalId).HasName("PK__tblPrinc__EB24D48FA1FCB238");

            entity.ToTable("tblPrincipal");

            entity.Property(e => e.PrincipalId).HasColumnName("PrincipalID");
            entity.Property(e => e.PrincipalFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrincipalFName");
            entity.Property(e => e.PrincipalLname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PrincipalLName");
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.StaffId)
                .HasDefaultValue(1)
                .HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblPrincipals)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPrincipal_tblStaff");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__tblStaff__96D4AAF7913651E2");

            entity.ToTable("tblStaff");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.StaffTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__tblStude__32C52A79889759F0");

            entity.ToTable("tblStudent");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StudentFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("StudentFName");
            entity.Property(e => e.StudentLname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("StudentLName");

            entity.HasOne(d => d.Class).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStudent_tblClass");
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__tblSubje__AC1BA388DB6CD0FD");

            entity.ToTable("tblSubject");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__tblTeach__EDF25944C6BCB30A");

            entity.ToTable("tblTeacher");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.StaffId)
                .HasDefaultValue(3)
                .HasColumnName("StaffID");
            entity.Property(e => e.TeacherFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TeacherFName");
            entity.Property(e => e.TeacherLname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TeacherLName");

            entity.HasOne(d => d.Department).WithMany(p => p.TblTeachers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTeacher_tblDepartment");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblTeachers)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTeacher_tblStaff");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
