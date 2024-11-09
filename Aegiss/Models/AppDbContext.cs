using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aegiss.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

    public virtual DbSet<CredentialEntry> CredentialEntries { get; set; }

    public virtual DbSet<EmailReset> EmailResets { get; set; }

    public virtual DbSet<ImageType> ImageTypes { get; set; }

    public virtual DbSet<LocationAccess> LocationAccesses { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<TableMapping> TableMappings { get; set; }

    public virtual DbSet<UserCharacteristic> UserCharacteristics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__APP_USER__3214EC27BB249A44");

            entity.ToTable("APP_USER", tb => tb.HasComment("Tabela que armazena os dados do usuário da aplicação."));

            entity.HasIndex(e => e.CreatedAt, "IX_APP_USER_CREATED_AT");

            entity.HasIndex(e => e.Email, "IX_APP_USER_EMAIL");

            entity.HasIndex(e => e.Name, "IX_APP_USER_NAME");

            entity.HasIndex(e => e.Username, "IX_APP_USER_USERNAME");

            entity.HasIndex(e => e.Email, "UQ__APP_USER__161CF724EC31C6E4").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__APP_USER__B15BE12EFCC78124").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Cidade do endereço do usuário da aplicação.")
                .HasColumnName("CITY");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Data de criação do usuário da aplicação.")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.DateOfBirth)
                .HasComment("Data de nascimento do usuário da aplicação.")
                .HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("E-mail do usuário da aplicação.")
                .HasColumnName("EMAIL");
            entity.Property(e => e.LastUsernameDateChange).HasColumnName("LAST_USERNAME_DATE_CHANGE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome do usuário da aplicação.")
                .HasColumnName("NAME");
            entity.Property(e => e.Neighborhood)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasComment("Bairro do endereço do usuário da aplicação.")
                .HasColumnName("NEIGHBORHOOD");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Número de telefone do usuário aplicação.")
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("REFRESH_TOKEN");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasComment("Estado do endereço do usuário da aplicação.")
                .HasColumnName("STATE");
            entity.Property(e => e.StreetName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasComment("Rua do endereço do usuário da aplicação.")
                .HasColumnName("STREET_NAME");
            entity.Property(e => e.StreetNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Número da rua do endereço do usuário da aplicação.")
                .HasColumnName("STREET_NUMBER");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Username para acesso à aplicação.")
                .HasColumnName("USERNAME");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("00000000")
                .HasComment("Cep do endereço do usuário da aplicação.")
                .HasColumnName("ZIP_CODE");
        });

        modelBuilder.Entity<ChangeLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHANGE_L__3214EC270AF6CF48");

            entity.ToTable("CHANGE_LOG");

            entity.HasIndex(e => e.ChangeTime, "IX_CHANGE_LOG_CHANGE_TIME");

            entity.HasIndex(e => e.ChangeType, "IX_CHANGE_LOG_CHANGE_TYPE");

            entity.HasIndex(e => e.ColumnName, "IX_CHANGE_LOG_COLUMN_NAME");

            entity.HasIndex(e => e.Responsible, "IX_CHANGE_LOG_RESPONSIBLE");

            entity.HasIndex(e => e.TableMappingId, "IX_CHANGE_LOG_TABLE_MAPPING_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChangeTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CHANGE_TIME");
            entity.Property(e => e.ChangeType).HasColumnName("CHANGE_TYPE");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLUMN_NAME");
            entity.Property(e => e.NewValue)
                .HasColumnType("sql_variant")
                .HasColumnName("NEW_VALUE");
            entity.Property(e => e.PreviousValue)
                .HasColumnType("sql_variant")
                .HasColumnName("PREVIOUS_VALUE");
            entity.Property(e => e.Record).HasColumnName("RECORD");
            entity.Property(e => e.Responsible)
                .HasDefaultValueSql("('0')")
                .HasColumnName("RESPONSIBLE");
            entity.Property(e => e.TableMappingId).HasColumnName("TABLE_MAPPING_ID");

            entity.HasOne(d => d.TableMapping).WithMany(p => p.ChangeLogs)
                .HasForeignKey(d => d.TableMappingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHANGE_LO__TABLE__0E6E26BF");
        });

        modelBuilder.Entity<CredentialEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CREDENTI__3214EC276A385B14");

            entity.ToTable("CREDENTIAL_ENTRY");

            entity.HasIndex(e => e.CreatedAt, "IX_CREDENTIAL_ENTRY_CREATED_AT");

            entity.HasIndex(e => e.Username, "IX_CREDENTIAL_ENTRY_USERNAME");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.LocationAccessId).HasColumnName("LOCATION_ACCESS_ID");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.LocationAccess).WithMany(p => p.CredentialEntries)
                .HasForeignKey(d => d.LocationAccessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CREDENTIA__LOCAT__02084FDA");
        });

        modelBuilder.Entity<EmailReset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMAIL_RE__3214EC27E0747D7E");

            entity.ToTable("EMAIL_RESETS");

            entity.HasIndex(e => e.NewEmail, "UQ__EMAIL_RE__66BC2EAC5DFA568C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppUserId).HasColumnName("APP_USER_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.ExpiresAt).HasColumnName("EXPIRES_AT");
            entity.Property(e => e.NewEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NEW_EMAIL");
            entity.Property(e => e.ValidationToken)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VALIDATION_TOKEN");

            entity.HasOne(d => d.AppUser).WithMany(p => p.EmailResets)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMAIL_RES__APP_U__7A672E12");
        });

        modelBuilder.Entity<ImageType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IMAGE_TY__3214EC27791906E4");

            entity.ToTable("IMAGE_TYPE");

            entity.HasIndex(e => e.TypeDescription, "IX_IMAGE_TYPE_TYPE_DESCRIPTION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TypeDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TYPE_DESCRIPTION");
        });

        modelBuilder.Entity<LocationAccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOCATION__3214EC2720E2587B");

            entity.ToTable("LOCATION_ACCESS");

            entity.HasIndex(e => e.AccessName, "IX_LOCATION_ACCESS_ACCESS_NAME");

            entity.HasIndex(e => e.CreatedAt, "IX_LOCATION_ACCESS_CREATED_AT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccessName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACCESS_NAME");
            entity.Property(e => e.AppUserId).HasColumnName("APP_USER_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_AT");

            entity.HasOne(d => d.AppUser).WithMany(p => p.LocationAccesses)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOCATION___APP_U__7E37BEF6");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PASSWORD__3214EC27C31E0FF7");

            entity.ToTable("PASSWORD_RESETS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppUserId).HasColumnName("APP_USER_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.ExpiresAt).HasColumnName("EXPIRES_AT");
            entity.Property(e => e.ValidationToken)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VALIDATION_TOKEN");

            entity.HasOne(d => d.AppUser).WithMany(p => p.PasswordResets)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PASSWORD___APP_U__75A278F5");
        });

        modelBuilder.Entity<TableMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TABLE_MA__3214EC2758A49047");

            entity.ToTable("TABLE_MAPPING");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TABLE_NAME");
        });

        modelBuilder.Entity<UserCharacteristic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER_CHA__3214EC27143F8DB2");

            entity.ToTable("USER_CHARACTERISTICS");

            entity.HasIndex(e => e.AppUserId, "IX_USER_CHARACTERISTICS_APP_USER_ID");

            entity.HasIndex(e => e.CreatedAt, "IX_USER_CHARACTERISTICS_CREATED_AT");

            entity.HasIndex(e => e.ImageTypeId, "IX_USER_CHARACTERISTICS_IMAGE_TYPE_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppUserId).HasColumnName("APP_USER_ID");
            entity.Property(e => e.CharacteristicsValue).HasColumnName("CHARACTERISTICS_VALUE");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.ImageTypeId).HasColumnName("IMAGE_TYPE_ID");

            entity.HasOne(d => d.AppUser).WithMany(p => p.UserCharacteristics)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER_CHAR__APP_U__07C12930");

            entity.HasOne(d => d.ImageType).WithMany(p => p.UserCharacteristics)
                .HasForeignKey(d => d.ImageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER_CHAR__IMAGE__08B54D69");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
