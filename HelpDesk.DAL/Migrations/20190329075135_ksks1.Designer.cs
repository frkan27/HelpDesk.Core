﻿// <auto-generated />
using System;
using HelpDesk.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpDesk.DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190329075135_ksks1")]
    partial class ksks1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelpDesk.Model.Entities.Poco.FaultLOG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorizeRole");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId")
                        .HasMaxLength(450);

                    b.Property<string>("Description");

                    b.Property<int>("FaultId");

                    b.HasKey("Id");

                    b.HasIndex("FaultId");

                    b.ToTable("FaultLOG");
                });

            modelBuilder.Entity("HelpDesk.Model.Entities.Poco.FaultRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("BillPath");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId")
                        .HasMaxLength(450);

                    b.Property<string>("CustomerId")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<DateTime>("FaultCreatedDate");

                    b.Property<string>("FaultDescription")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("FaultLastCheckDate");

                    b.Property<int>("FaultRecordState");

                    b.Property<DateTime?>("FaultSolveDate");

                    b.Property<int>("FitechBehaviorScorei");

                    b.Property<bool>("OperatorAccept");

                    b.Property<DateTime?>("OperatorAcceptDate");

                    b.Property<string>("OperatorId");

                    b.Property<string>("OpinionsAboutFitech");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("ServiceScore");

                    b.Property<string>("SurveyCode");

                    b.Property<bool>("SurveyIsCompleted");

                    b.Property<DateTime?>("TechnicianAppointedDate");

                    b.Property<int>("TechnicianBehaviorScore");

                    b.Property<string>("TechnicianId");

                    b.Property<int>("TechnicianInfoPoints");

                    b.Property<int>("TechnicianState");

                    b.Property<double?>("latitude");

                    b.Property<double?>("longitude");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OperatorId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("FaultRecords");
                });

            modelBuilder.Entity("HelpDesk.Model.Entities.Poco.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId")
                        .HasMaxLength(450);

                    b.Property<int>("FaultId");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FaultId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("HelpDesk.Model.IdentityEntities.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Desc")
                        .HasMaxLength(128);

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

            modelBuilder.Entity("HelpDesk.Model.IdentityEntities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ActivationCode");

                    b.Property<string>("AvatarPath");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<double?>("Latitude");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<double?>("Longtitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisteredDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

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
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

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

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HelpDesk.Model.Entities.Poco.FaultLOG", b =>
                {
                    b.HasOne("HelpDesk.Model.Entities.Poco.FaultRecord", "Fault")
                        .WithMany()
                        .HasForeignKey("FaultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDesk.Model.Entities.Poco.FaultRecord", b =>
                {
                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId");

                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");
                });

            modelBuilder.Entity("HelpDesk.Model.Entities.Poco.Photo", b =>
                {
                    b.HasOne("HelpDesk.Model.Entities.Poco.FaultRecord", "FaultRecord")
                        .WithMany("Photos")
                        .HasForeignKey("FaultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HelpDesk.Model.IdentityEntities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
