using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\פרויקט ריקי ורחלי\\C#\\Dal\\DataBase.mdf\";Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC07017BEC4C");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.Eventts).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassEvent",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventtId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_eventtId_classEvents"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_classId_classEvents"),
                    j =>
                    {
                        j.HasKey("ClassId", "EventtId").HasName("PK__ClassEve__289ADADD6C9D3F58");
                        j.ToTable("ClassEvents");
                        j.IndexerProperty<int>("ClassId").HasColumnName("classId");
                        j.IndexerProperty<int>("EventtId").HasColumnName("eventtId");
                    });
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0710EFD2F1");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.MaxClass).HasColumnName("maxClass");
            entity.Property(e => e.MinClass).HasColumnName("minClass");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Place)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("place");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07A3AC7E12");

            entity.ToTable("parents");

            entity.Property(e => e.Accepted).HasColumnName("accepted");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("address");
            entity.Property(e => e.FamilyLastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("familyLastName");
            entity.Property(e => e.FatherFirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("fatherFirstName");
            entity.Property(e => e.HomeNumberPhone)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("homeNumberPhone");
            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("mail");
            entity.Property(e => e.MotherFirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("motherFirstName");
            entity.Property(e => e.NumberPhone1)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("numberPhone1");
            entity.Property(e => e.NumberPhone2)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("numberPhone2");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.StudentId }).HasName("PK__Registra__F916A06AC3F1C485");

            entity.ToTable("Registration");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");

            entity.HasOne(d => d.Event).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_eRegistration");

            entity.HasOne(d => d.Student).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sRegistration");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07BDF1CECA");

            entity.ToTable("Student");

            entity.Property(e => e.Accepted).HasColumnName("accepted");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Name)
                .HasMaxLength(12)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.ParentsId).HasColumnName("parentsId");

            entity.HasOne(d => d.Parents).WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pStudent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
