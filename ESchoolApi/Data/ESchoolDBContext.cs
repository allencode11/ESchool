using ESchoolApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ESchoolApi.Data;

public partial class ESchoolDBContext : DbContext
{
    public ESchoolDBContext()
    {
    }

    public ESchoolDBContext(DbContextOptions<ESchoolDBContext> options) : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<Discipline> Disciplines { get; set; }
    public virtual DbSet<Qualification> Qualifications { get; set; }
    public virtual DbSet<UsersQualification> UsersQualifications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

       modelBuilder.Entity<UsersQualification>()
            .Property(bc =>bc.Id).ValueGeneratedOnAdd();  
        
        modelBuilder.Entity<UsersQualification>()
            .HasOne(bc => bc.User)
            .WithMany(b => b.UsersQualifications)
            .HasForeignKey(bc => bc.UserId);  
        
        modelBuilder.Entity<UsersQualification>()
            .HasOne(bc => bc.Qualification)
            .WithMany(b => b.UsersQualifications)
            .HasForeignKey(bc => bc.QualificationId);  
        
        
        modelBuilder.Entity<User>()
            .HasMany(bc => bc.UsersQualifications)
            .WithOne(b => b.User)
            .HasForeignKey(bc => bc.UserId);  
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("Users");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Username).HasMaxLength(60).IsUnicode(false);
            entity.Property(e => e.Surname).HasMaxLength(30).IsUnicode(false).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false).IsRequired();
            entity.Property(e => e.Role).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Institution).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.CreatedAt).IsUnicode(false);
            
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.ToTable("Qualifications");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DisciplineId).IsUnicode(false);

        });
        
        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.ToTable("Disciplines");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name).HasMaxLength(25).IsUnicode(false);
        });
        
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("Grades");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name).HasMaxLength(15).HasDefaultValue(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}