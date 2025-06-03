using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVVM_spring.Models;

public partial class PrImportContext : DbContext
{
    public PrImportContext()
    {
    }

    public PrImportContext(DbContextOptions<PrImportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CityEvent> CityEvents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventActivity> EventActivities { get; set; }

    public virtual DbSet<EventCharacteristic> EventCharacteristics { get; set; }

    public virtual DbSet<EventJudge> EventJudges { get; set; }

    public virtual DbSet<EventSection> EventSections { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TempUser> TempUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCountry> UserCountries { get; set; }

    public virtual DbSet<UserEvent> UserEvents { get; set; }

    public virtual DbSet<UserEventSection> UserEventSections { get; set; }

    public virtual DbSet<UserGender> UserGenders { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GTC3K6T;Database=prImport;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activity__45F4A7F1AE6915E3");

            entity.ToTable("Activity");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ActivityName).HasMaxLength(100);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A96F50A5470");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(100);
        });

        modelBuilder.Entity<CityEvent>(entity =>
        {
            entity.HasKey(e => e.CityEventId).HasName("PK__City_Eve__916C1A8087BDCA4B");

            entity.ToTable("City_Event");

            entity.HasIndex(e => new { e.CityId, e.EventId }, "UQ_CityEvent").IsUnique();

            entity.Property(e => e.CityEventId).HasColumnName("CityEventID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.City).WithMany(p => p.CityEvents)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityEvent_City");

            entity.HasOne(d => d.Event).WithMany(p => p.CityEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityEvent_Event");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCodeNumber).HasName("PK__Country__B0A2BED067150032");

            entity.ToTable("Country");

            entity.HasIndex(e => e.CountryCodeNumber, "UQ_CountryCodeNumber").IsUnique();

            entity.Property(e => e.CountryCodeNumber).ValueGeneratedNever();
            entity.Property(e => e.CountryCodeChar)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryNameEng).HasMaxLength(100);
            entity.Property(e => e.CountryNameRu).HasMaxLength(100);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C870B67797AA");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(100);
        });

        modelBuilder.Entity<EventActivity>(entity =>
        {
            entity.HasKey(e => e.EventActivityId).HasName("PK__Event_Ac__6B6E803C8F24A17A");

            entity.ToTable("Event_Activity");

            entity.HasIndex(e => new { e.EventId, e.ActivityId, e.UserId }, "UQ_EventActivity").IsUnique();

            entity.Property(e => e.EventActivityId).HasColumnName("EventActivityID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Activity).WithMany(p => p.EventActivities)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventActivity_Activity");

            entity.HasOne(d => d.Event).WithMany(p => p.EventActivities)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventActivity_Event");

            entity.HasOne(d => d.User).WithMany(p => p.EventActivities)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventActivity_User");
        });

        modelBuilder.Entity<EventCharacteristic>(entity =>
        {
            entity.HasKey(e => e.EventCharacteristicId).HasName("PK__EventCha__23A600BE5C948871");

            entity.ToTable("EventCharacteristic");

            entity.HasIndex(e => new { e.EventId, e.EventTypeId, e.EventSectionId }, "UQ_EventCharacteristic").IsUnique();

            entity.Property(e => e.EventCharacteristicId).HasColumnName("EventCharacteristicID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventSectionId).HasColumnName("EventSectionID");
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventCharacteristics)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventCharacteristic_Event");

            entity.HasOne(d => d.EventSection).WithMany(p => p.EventCharacteristics)
                .HasForeignKey(d => d.EventSectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventCharacteristic_Section");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventCharacteristics)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventCharacteristic_Type");
        });

        modelBuilder.Entity<EventJudge>(entity =>
        {
            entity.HasKey(e => e.EventJudgeId).HasName("PK__EventJud__89FCE656F40F7CAD");

            entity.ToTable("EventJudge");

            entity.HasIndex(e => new { e.EventId, e.ActivityId, e.UserId }, "UQ_EventJudge").IsUnique();

            entity.Property(e => e.EventJudgeId).HasColumnName("EventJudgeID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Activity).WithMany(p => p.EventJudges)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventJudge_Activity");

            entity.HasOne(d => d.Event).WithMany(p => p.EventJudges)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventJudge_Event");

            entity.HasOne(d => d.User).WithMany(p => p.EventJudges)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventJudge_User");
        });

        modelBuilder.Entity<EventSection>(entity =>
        {
            entity.HasKey(e => e.EventSectionId).HasName("PK__EventSec__6FDEE17A51AB82D6");

            entity.ToTable("EventSection");

            entity.Property(e => e.EventSectionId).HasColumnName("EventSectionID");
            entity.Property(e => e.EventSectionName).HasMaxLength(100);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__EventTyp__A9216B1F7639F2AC");

            entity.ToTable("EventType");

            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.EventTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Gender__4E24E8174B9CB100");

            entity.ToTable("Gender");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3AF42FCF80");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TempUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TempUser__1788CCAC3E7A0CE8");

            entity.ToTable("TempUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserEmail).HasMaxLength(100);
            entity.Property(e => e.UserLastName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(255);
            entity.Property(e => e.UserPhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UserSurname).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC4E33084A");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserEmail).HasMaxLength(100);
            entity.Property(e => e.UserLastName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(255);
            entity.Property(e => e.UserPhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UserSurname).HasMaxLength(50);
        });

        modelBuilder.Entity<UserCountry>(entity =>
        {
            entity.HasKey(e => e.UserCountryId).HasName("PK__User_Cou__F6E27409BAD21A56");

            entity.ToTable("User_Country");

            entity.HasIndex(e => new { e.UserId, e.CountryCodeNumber }, "UQ_UserCountry").IsUnique();

            entity.Property(e => e.UserCountryId).HasColumnName("UserCountryID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.CountryCodeNumberNavigation).WithMany(p => p.UserCountries)
                .HasForeignKey(d => d.CountryCodeNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCountry_Country");

            entity.HasOne(d => d.User).WithMany(p => p.UserCountries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCountry_User");
        });

        modelBuilder.Entity<UserEvent>(entity =>
        {
            entity.HasKey(e => e.UserEventId).HasName("PK__User_Eve__C59E16D96EF66359");

            entity.ToTable("User_Event");

            entity.HasIndex(e => new { e.UserId, e.EventId }, "UQ_UserEvent").IsUnique();

            entity.Property(e => e.UserEventId).HasColumnName("UserEventID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Event).WithMany(p => p.UserEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEvent_Event");

            entity.HasOne(d => d.User).WithMany(p => p.UserEvents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEvent_User");
        });

        modelBuilder.Entity<UserEventSection>(entity =>
        {
            entity.HasKey(e => e.UserEventSectionId).HasName("PK__User_Eve__9EDDD8665F8A8986");

            entity.ToTable("User_EventSection");

            entity.HasIndex(e => new { e.UserId, e.EventSectionId }, "UQ_UserEventSection").IsUnique();

            entity.Property(e => e.UserEventSectionId).HasColumnName("UserEventSectionID");
            entity.Property(e => e.EventSectionId).HasColumnName("EventSectionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.EventSection).WithMany(p => p.UserEventSections)
                .HasForeignKey(d => d.EventSectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEventSection_EventSection");

            entity.HasOne(d => d.User).WithMany(p => p.UserEventSections)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEventSection_User");
        });

        modelBuilder.Entity<UserGender>(entity =>
        {
            entity.HasKey(e => e.UserGenderId).HasName("PK__User_Gen__C51D392F0F8EB0A6");

            entity.ToTable("User_Gender");

            entity.HasIndex(e => new { e.UserId, e.GenderId }, "UQ_UserGender").IsUnique();

            entity.Property(e => e.UserGenderId).HasColumnName("UserGenderID");
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Gender).WithMany(p => p.UserGenders)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGender_Gender");

            entity.HasOne(d => d.User).WithMany(p => p.UserGenders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGender_User");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__User_Rol__3D978A55BB89475B");

            entity.ToTable("User_Role");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "UQ_UserRole").IsUnique();

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
