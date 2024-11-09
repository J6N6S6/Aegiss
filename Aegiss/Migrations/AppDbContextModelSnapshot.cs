﻿// <auto-generated />
using System;
using Aegiss.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aegiss.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aegiss.Models.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CITY")
                        .HasComment("Cidade do endereço do usuário da aplicação.");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT")
                        .HasDefaultValueSql("(getdate())")
                        .HasComment("Data de criação do usuário da aplicação.");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("DATE_OF_BIRTH")
                        .HasComment("Data de nascimento do usuário da aplicação.");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("EMAIL")
                        .HasComment("E-mail do usuário da aplicação.");

                    b.Property<DateTime?>("LastUsernameDateChange")
                        .HasColumnType("datetime2")
                        .HasColumnName("LAST_USERNAME_DATE_CHANGE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME")
                        .HasComment("Nome do usuário da aplicação.");

                    b.Property<string>("Neighborhood")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("NEIGHBORHOOD")
                        .HasComment("Bairro do endereço do usuário da aplicação.");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PHONE_NUMBER")
                        .HasComment("Número de telefone do usuário aplicação.");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("REFRESH_TOKEN");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("STATE")
                        .HasComment("Estado do endereço do usuário da aplicação.");

                    b.Property<string>("StreetName")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("STREET_NAME")
                        .HasComment("Rua do endereço do usuário da aplicação.");

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("STREET_NUMBER")
                        .HasComment("Número da rua do endereço do usuário da aplicação.");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("USERNAME")
                        .HasComment("Username para acesso à aplicação.");

                    b.Property<string>("ZipCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasDefaultValue("00000000")
                        .HasColumnName("ZIP_CODE")
                        .HasComment("Cep do endereço do usuário da aplicação.");

                    b.HasKey("Id")
                        .HasName("PK__APP_USER__3214EC27BB249A44");

                    b.HasIndex(new[] { "CreatedAt" }, "IX_APP_USER_CREATED_AT");

                    b.HasIndex(new[] { "Email" }, "IX_APP_USER_EMAIL");

                    b.HasIndex(new[] { "Name" }, "IX_APP_USER_NAME");

                    b.HasIndex(new[] { "Username" }, "IX_APP_USER_USERNAME");

                    b.HasIndex(new[] { "Email" }, "UQ__APP_USER__161CF724EC31C6E4")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UQ__APP_USER__B15BE12EFCC78124")
                        .IsUnique();

                    b.ToTable("APP_USER", null, t =>
                        {
                            t.HasComment("Tabela que armazena os dados do usuário da aplicação.");
                        });
                });

            modelBuilder.Entity("Aegiss.Models.ChangeLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ChangeTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CHANGE_TIME")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<short>("ChangeType")
                        .HasColumnType("smallint")
                        .HasColumnName("CHANGE_TYPE");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("COLUMN_NAME");

                    b.Property<object>("NewValue")
                        .HasColumnType("sql_variant")
                        .HasColumnName("NEW_VALUE");

                    b.Property<object>("PreviousValue")
                        .HasColumnType("sql_variant")
                        .HasColumnName("PREVIOUS_VALUE");

                    b.Property<long>("Record")
                        .HasColumnType("bigint")
                        .HasColumnName("RECORD");

                    b.Property<long>("Responsible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("RESPONSIBLE")
                        .HasDefaultValueSql("('0')");

                    b.Property<long>("TableMappingId")
                        .HasColumnType("bigint")
                        .HasColumnName("TABLE_MAPPING_ID");

                    b.HasKey("Id")
                        .HasName("PK__CHANGE_L__3214EC270AF6CF48");

                    b.HasIndex(new[] { "ChangeTime" }, "IX_CHANGE_LOG_CHANGE_TIME");

                    b.HasIndex(new[] { "ChangeType" }, "IX_CHANGE_LOG_CHANGE_TYPE");

                    b.HasIndex(new[] { "ColumnName" }, "IX_CHANGE_LOG_COLUMN_NAME");

                    b.HasIndex(new[] { "Responsible" }, "IX_CHANGE_LOG_RESPONSIBLE");

                    b.HasIndex(new[] { "TableMappingId" }, "IX_CHANGE_LOG_TABLE_MAPPING_ID");

                    b.ToTable("CHANGE_LOG", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.CredentialEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long>("LocationAccessId")
                        .HasColumnType("bigint")
                        .HasColumnName("LOCATION_ACCESS_ID");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id")
                        .HasName("PK__CREDENTI__3214EC276A385B14");

                    b.HasIndex("LocationAccessId");

                    b.HasIndex(new[] { "CreatedAt" }, "IX_CREDENTIAL_ENTRY_CREATED_AT");

                    b.HasIndex(new[] { "Username" }, "IX_CREDENTIAL_ENTRY_USERNAME");

                    b.ToTable("CREDENTIAL_ENTRY", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.EmailReset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("APP_USER_ID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("EXPIRES_AT");

                    b.Property<string>("NewEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NEW_EMAIL");

                    b.Property<string>("ValidationToken")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("VALIDATION_TOKEN");

                    b.HasKey("Id")
                        .HasName("PK__EMAIL_RE__3214EC27E0747D7E");

                    b.HasIndex("AppUserId");

                    b.HasIndex(new[] { "NewEmail" }, "UQ__EMAIL_RE__66BC2EAC5DFA568C")
                        .IsUnique();

                    b.ToTable("EMAIL_RESETS", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.ImageType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TYPE_DESCRIPTION");

                    b.HasKey("Id")
                        .HasName("PK__IMAGE_TY__3214EC27791906E4");

                    b.HasIndex(new[] { "TypeDescription" }, "IX_IMAGE_TYPE_TYPE_DESCRIPTION");

                    b.ToTable("IMAGE_TYPE", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.LocationAccess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AccessName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ACCESS_NAME");

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("APP_USER_ID");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__LOCATION__3214EC2720E2587B");

                    b.HasIndex("AppUserId");

                    b.HasIndex(new[] { "AccessName" }, "IX_LOCATION_ACCESS_ACCESS_NAME");

                    b.HasIndex(new[] { "CreatedAt" }, "IX_LOCATION_ACCESS_CREATED_AT");

                    b.ToTable("LOCATION_ACCESS", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.PasswordReset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("APP_USER_ID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("EXPIRES_AT");

                    b.Property<string>("ValidationToken")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("VALIDATION_TOKEN");

                    b.HasKey("Id")
                        .HasName("PK__PASSWORD__3214EC27C31E0FF7");

                    b.HasIndex("AppUserId");

                    b.ToTable("PASSWORD_RESETS", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.TableMapping", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TABLE_NAME");

                    b.HasKey("Id")
                        .HasName("PK__TABLE_MA__3214EC2758A49047");

                    b.ToTable("TABLE_MAPPING", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.UserCharacteristic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("APP_USER_ID");

                    b.Property<byte[]>("CharacteristicsValue")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("CHARACTERISTICS_VALUE");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<short>("ImageTypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("IMAGE_TYPE_ID");

                    b.HasKey("Id")
                        .HasName("PK__USER_CHA__3214EC27143F8DB2");

                    b.HasIndex(new[] { "AppUserId" }, "IX_USER_CHARACTERISTICS_APP_USER_ID");

                    b.HasIndex(new[] { "CreatedAt" }, "IX_USER_CHARACTERISTICS_CREATED_AT");

                    b.HasIndex(new[] { "ImageTypeId" }, "IX_USER_CHARACTERISTICS_IMAGE_TYPE_ID");

                    b.ToTable("USER_CHARACTERISTICS", (string)null);
                });

            modelBuilder.Entity("Aegiss.Models.ChangeLog", b =>
                {
                    b.HasOne("Aegiss.Models.TableMapping", "TableMapping")
                        .WithMany("ChangeLogs")
                        .HasForeignKey("TableMappingId")
                        .IsRequired()
                        .HasConstraintName("FK__CHANGE_LO__TABLE__0E6E26BF");

                    b.Navigation("TableMapping");
                });

            modelBuilder.Entity("Aegiss.Models.CredentialEntry", b =>
                {
                    b.HasOne("Aegiss.Models.LocationAccess", "LocationAccess")
                        .WithMany("CredentialEntries")
                        .HasForeignKey("LocationAccessId")
                        .IsRequired()
                        .HasConstraintName("FK__CREDENTIA__LOCAT__02084FDA");

                    b.Navigation("LocationAccess");
                });

            modelBuilder.Entity("Aegiss.Models.EmailReset", b =>
                {
                    b.HasOne("Aegiss.Models.AppUser", "AppUser")
                        .WithMany("EmailResets")
                        .HasForeignKey("AppUserId")
                        .IsRequired()
                        .HasConstraintName("FK__EMAIL_RES__APP_U__7A672E12");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Aegiss.Models.LocationAccess", b =>
                {
                    b.HasOne("Aegiss.Models.AppUser", "AppUser")
                        .WithMany("LocationAccesses")
                        .HasForeignKey("AppUserId")
                        .IsRequired()
                        .HasConstraintName("FK__LOCATION___APP_U__7E37BEF6");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Aegiss.Models.PasswordReset", b =>
                {
                    b.HasOne("Aegiss.Models.AppUser", "AppUser")
                        .WithMany("PasswordResets")
                        .HasForeignKey("AppUserId")
                        .IsRequired()
                        .HasConstraintName("FK__PASSWORD___APP_U__75A278F5");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Aegiss.Models.UserCharacteristic", b =>
                {
                    b.HasOne("Aegiss.Models.AppUser", "AppUser")
                        .WithMany("UserCharacteristics")
                        .HasForeignKey("AppUserId")
                        .IsRequired()
                        .HasConstraintName("FK__USER_CHAR__APP_U__07C12930");

                    b.HasOne("Aegiss.Models.ImageType", "ImageType")
                        .WithMany("UserCharacteristics")
                        .HasForeignKey("ImageTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__USER_CHAR__IMAGE__08B54D69");

                    b.Navigation("AppUser");

                    b.Navigation("ImageType");
                });

            modelBuilder.Entity("Aegiss.Models.AppUser", b =>
                {
                    b.Navigation("EmailResets");

                    b.Navigation("LocationAccesses");

                    b.Navigation("PasswordResets");

                    b.Navigation("UserCharacteristics");
                });

            modelBuilder.Entity("Aegiss.Models.ImageType", b =>
                {
                    b.Navigation("UserCharacteristics");
                });

            modelBuilder.Entity("Aegiss.Models.LocationAccess", b =>
                {
                    b.Navigation("CredentialEntries");
                });

            modelBuilder.Entity("Aegiss.Models.TableMapping", b =>
                {
                    b.Navigation("ChangeLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
