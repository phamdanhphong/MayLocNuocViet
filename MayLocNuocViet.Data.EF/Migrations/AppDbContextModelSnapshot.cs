﻿// <auto-generated />
using System;
using Fsoft.SKU.CoreApp.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fsoft.SKU.CoreApp.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.AuditTrailLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .HasMaxLength(255);

                    b.Property<DateTime>("ChangeTime");

                    b.Property<string>("NewValue")
                        .HasMaxLength(3000);

                    b.Property<string>("OldValue")
                        .HasMaxLength(3000);

                    b.Property<string>("RecordId")
                        .HasMaxLength(100);

                    b.Property<string>("TableName")
                        .HasMaxLength(255);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AuditTrailLogs");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ParentId")
                        .HasMaxLength(255);

                    b.Property<string>("Path")
                        .HasMaxLength(255);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.EmailAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<bool>("EnableSsl");

                    b.Property<string>("Host");

                    b.Property<string>("Password");

                    b.Property<int>("Port");

                    b.Property<bool>("UseDefaultCredentials");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Core_EmailAccount");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("Core_EmailTemplate");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.GroupRole", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<int>("GroupId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("RoleId", "GroupId");

                    b.HasAlternateKey("GroupId", "RoleId");

                    b.ToTable("GroupRoles");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Note")
                        .HasMaxLength(255);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.NotificationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Id_Notification");

                    b.Property<string>("Note")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("PushDate");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Id_Notification");

                    b.HasIndex("UserId");

                    b.ToTable("NotificationHistorys");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Note")
                        .HasMaxLength(2000);

                    b.Property<string>("ParameterCode")
                        .HasMaxLength(20);

                    b.Property<string>("ParameterType")
                        .HasMaxLength(20);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Value")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<int>("MenuId");

                    b.Property<bool>("CanCreate");

                    b.Property<bool>("CanDelete");

                    b.Property<bool>("CanExport");

                    b.Property<bool>("CanImport");

                    b.Property<bool>("CanRead");

                    b.Property<bool>("CanUpdate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("RoleId", "MenuId");

                    b.HasAlternateKey("MenuId", "RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<string>("Avatar")
                        .HasMaxLength(255);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DepartmentRefId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<Guid>("ManagerId");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone")
                        .HasMaxLength(255);

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Setting")
                        .HasMaxLength(255);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.UserInGroup", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<int>("GroupId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("UserId", "GroupId");

                    b.HasAlternateKey("GroupId", "UserId");

                    b.ToTable("UserInGroups");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasAlternateKey("RoleId", "UserId");

                    b.ToTable("UserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.ToTable("UserRoles");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.GroupRole", b =>
                {
                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.Group", "Group")
                        .WithMany("GroupRoles")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.Role", "Role")
                        .WithMany("GroupRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.NotificationHistory", b =>
                {
                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.Notification", "Notification")
                        .WithMany("NotificationHistories")
                        .HasForeignKey("Id_Notification")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.User", "User")
                        .WithMany("NotificationHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.RolePermission", b =>
                {
                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.Menu", "Menu")
                        .WithMany("RolePermissions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fsoft.SKU.CoreApp.Data.Entities.UserInGroup", b =>
                {
                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.Group", "Group")
                        .WithMany("UserInGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fsoft.SKU.CoreApp.Data.Entities.User", "User")
                        .WithMany("UserInGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
