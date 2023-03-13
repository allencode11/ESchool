using ESchoolApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ESchoolApi.Data;

public partial class ESchoolDBContext : DbContext
{
    public ESchoolDBContext(DbContextOptions<ESchoolDBContext> options) : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<Discipline> Disciplines { get; set; }
    public virtual DbSet<Qualification> Qualifications { get; set; }
    public virtual DbSet<UsersQualification> UsersQualifications { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<User>(entity =>
    //     {
    //         entity.HasNoKey();
    //         entity.ToTable("Users");
    //         entity.Property(e => e.Id).HasColumnName("Id");
    //         entity.Property(e => e.Username).HasMaxLength(60).IsUnicode(false);
    //         entity.Property(e => e.Surname).HasMaxLength(30).IsUnicode(false).IsRequired();
    //         entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false).IsRequired();
    //         entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false).IsRequired();
    //         entity.Property(e => e.Role).HasMaxLength(50).IsUnicode(false);
    //         entity.Property(e => e.Institution).HasMaxLength(50).IsUnicode(false);
    //         entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
    //         entity.Property(e => e.CreatedAt).IsUnicode(false);
    //     });
    //     
    //     modelBuilder.Entity<Qualification>(entity =>
    //     {
    //         entity.ToTable("Qualifications");
    //         entity.Property(e => e.Id).HasColumnName("Id");
    //         entity.Property(e => e.DisciplineId).IsUnicode(false);
    //
    //     });
    //     
    //     modelBuilder.Entity<Discipline>(entity =>
    //     {
    //         entity.ToTable("Disciplines");
    //         entity.Property(e => e.Id).HasColumnName("Id");
    //         entity.Property(e => e.Name).HasMaxLength(25).IsUnicode(false);
    //     });
    //     
    //     modelBuilder.Entity<Grade>(entity =>
    //     {
    //         entity.ToTable("Grades");
    //         entity.Property(e => e.Id).HasColumnName("Id");
    //         entity.Property(e => e.Name).HasMaxLength(15).HasDefaultValue(false);
    //     });
    //     
    //     modelBuilder.Entity<UsersQualification>(entity =>
    //     {
    //         entity.ToTable("UsersQualifications");
    //         entity.Property(e => e.Id).HasColumnName("Id");
    //         entity.Property(e => e.UserId);
    //         entity.Property(e => e.QualificationId);
    //         entity.Property(e => e.Users);
    //         entity.Property(e => e.Qualifications);
    //     });
    // }
}