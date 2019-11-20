﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAsada.Data;

namespace WebAsada.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191119235338_tablas_supplier_producttype")]
    partial class tablas_supplier_producttype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebAsada.Models.Charge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChargeCode");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Nemotecnico");

                    b.Property<string>("OfficialId");

                    b.Property<double>("Price");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Charge");
                });

            modelBuilder.Entity("WebAsada.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("WebAsada.Models.ContractType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractTypeCode");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Nemotecnico");

                    b.Property<string>("OfficialId");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("ContractType");
                });

            modelBuilder.Entity("WebAsada.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym");

                    b.Property<string>("CurrencyCode");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Nemotecnico");

                    b.Property<string>("OfficialId");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("WebAsada.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsGeneralTable");

                    b.Property<string>("Name");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("WebAsada.Models.Estate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias");

                    b.Property<double>("Area");

                    b.Property<string>("CadastralPlans");

                    b.Property<string>("Comments");

                    b.Property<string>("ExactAddress");

                    b.Property<string>("RealFolio");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Estate");
                });

            modelBuilder.Entity("WebAsada.Models.IdentificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentificationTypeCode");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Nemotecnico");

                    b.Property<string>("OfficialId");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("IdentificationType");
                });

            modelBuilder.Entity("WebAsada.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<DateTime>("MaxPaymentDate");

                    b.Property<string>("MessageOfTheMonth");

                    b.Property<int>("MonthId");

                    b.Property<string>("PaymentPlace");

                    b.Property<DateTime>("ReadDate");

                    b.Property<string>("ReadUserId");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("MonthId");

                    b.HasIndex("ReadUserId");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("WebAsada.Models.Month", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nemotecnico");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Month");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nemotecnico = "ENERO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Enero",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Nemotecnico = "FEBRERO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Febrero",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Nemotecnico = "MARZO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Marzo",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Nemotecnico = "ABRIL",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Abril",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Nemotecnico = "MAYO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Mayo",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Nemotecnico = "JUNIO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Junio",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Nemotecnico = "JULIO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Julio",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Nemotecnico = "AGOSTO",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Agosto",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Nemotecnico = "SEPTIEMBRE",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Septiembre",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Nemotecnico = "OCTUBRE",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Octubre",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            Nemotecnico = "NOVIEMBRE",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Noviembre",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            Nemotecnico = "DICIEMBRE",
                            RegisterDatime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShortDesc = "Diciembre",
                            UpdateDateTime = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebAsada.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstLastName");

                    b.Property<string>("IdentificationNumber");

                    b.Property<int>("IdentificationTypeId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("PersonTypeId");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("SecondLastName");

                    b.Property<string>("TelephoneNumber");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("IdentificationTypeId");

                    b.HasIndex("PersonTypeId");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("WebAsada.Models.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Nemotecnico");

                    b.Property<string>("OfficialId");

                    b.Property<string>("PersonTypeCode");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("CustomerType");
                });

            modelBuilder.Entity("WebAsada.Models.PersonsByEstate", b =>
                {
                    b.Property<int>("EstateId");

                    b.Property<int>("PersonId");

                    b.HasKey("EstateId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonsByEstate");
                });

            modelBuilder.Entity("WebAsada.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Nemotecnico");

                    b.Property<string>("OfficialId");

                    b.Property<string>("ProductTypeCode");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("ShortDesc");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("WebAsada.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContractId");

                    b.Property<int?>("MeasurementId");

                    b.Property<double>("NewRead");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<double>("TotalAmount");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("MeasurementId");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("WebAsada.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Comments");

                    b.Property<string>("ContactName");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("ProductTypeId");

                    b.Property<DateTime>("RegisterDatime");

                    b.Property<string>("RegisterUserId");

                    b.Property<string>("Schedule");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<string>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("RegisterUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAsada.Models.Charge", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Contract", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.ContractType", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Currency", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Entity", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Estate", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.IdentificationType", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Measurement", b =>
                {
                    b.HasOne("WebAsada.Models.Month", "Month")
                        .WithMany()
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "ReadUser")
                        .WithMany()
                        .HasForeignKey("ReadUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Month", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Person", b =>
                {
                    b.HasOne("WebAsada.Models.IdentificationType", "IdentificationType")
                        .WithMany()
                        .HasForeignKey("IdentificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAsada.Models.PersonType", "PersonType")
                        .WithMany()
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.PersonType", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.PersonsByEstate", b =>
                {
                    b.HasOne("WebAsada.Models.Estate", "Estate")
                        .WithMany("PersonsByEstateCollection")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAsada.Models.Person", "Person")
                        .WithMany("PersonsByEstate")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAsada.Models.ProductType", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Receipt", b =>
                {
                    b.HasOne("WebAsada.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.HasOne("WebAsada.Models.Measurement", "Measurement")
                        .WithMany()
                        .HasForeignKey("MeasurementId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });

            modelBuilder.Entity("WebAsada.Models.Supplier", b =>
                {
                    b.HasOne("WebAsada.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "RegisterUser")
                        .WithMany()
                        .HasForeignKey("RegisterUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
