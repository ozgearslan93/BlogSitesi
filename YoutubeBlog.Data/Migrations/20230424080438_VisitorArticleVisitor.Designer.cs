﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoutubeBlog.Data.Context;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230424080438_VisitorArticleVisitor")]
    partial class VisitorArticleVisitor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7202d761-fc41-483d-8ac3-a055797ebfb0"),
                            ConcurrencyStamp = "0b58ac28-0299-4d24-aba4-fb40b2977235",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("1c48e849-e8d7-46ee-aa61-a6fda42d7929"),
                            ConcurrencyStamp = "9aa0d7cf-129c-4ddf-a5f8-2d8ca68d6537",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("26a9a330-7671-47da-a1bf-e10f8432e2db"),
                            ConcurrencyStamp = "e3a42d1f-c8ac-4bf0-af4f-235936511276",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("28235d4c-8428-47b8-96c3-7ae23ebafca9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6f9f3715-b9be-44c1-b25e-d16c9cf59016",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Cem",
                            ImageId = new Guid("4b7e17f3-1096-443d-a24f-ca83de5b740b"),
                            LastName = "Keskin",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEM+q1PFZ80UW+WXv+LItJ+V9LYmhduOzRhoDNawjguA5XVW5725IbzQI8RhgSGfRpQ==",
                            PhoneNumber = "+905439999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "54479ed7-7636-4017-a8dd-5370150a50fb",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("62a1399a-9802-41ea-9b25-68c523af5783"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3a6a45e1-7079-45f6-b974-ed7c2022a54c",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            ImageId = new Guid("df826779-4901-4e2f-ab80-4f1ce6033ed1"),
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEAOj6QpHCNJGPjnSTsu1j3CFTknFaBksZlj/hcsTYKhgJfIcxncFNyQG1rzbnQYnQw==",
                            PhoneNumber = "+905439999988",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1129c093-0820-4218-a7a2-07a4258f9280",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("28235d4c-8428-47b8-96c3-7ae23ebafca9"),
                            RoleId = new Guid("7202d761-fc41-483d-8ac3-a055797ebfb0")
                        },
                        new
                        {
                            UserId = new Guid("62a1399a-9802-41ea-9b25-68c523af5783"),
                            RoleId = new Guid("1c48e849-e8d7-46ee-aa61-a6fda42d7929")
                        });
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c964451-dbc3-4606-bf81-1986ecc100e9"),
                            CategoryId = new Guid("18c390e3-807f-4890-b74d-a3b0bd6b2364"),
                            Content = "Asp.net Core Lorem ipsum dolor sit amet consectetur adipiscing elit posuere vivamus, potenti habitant bibendum luctus lacus mus non risus. Dis habitant est suscipit nunc iaculis non mollis mi nibh rhoncus dignissim facilisi, laoreet per id pretium vivamus bibendum sociis ultricies facilisis auctor. Etiam at eleifend montes lacinia orci molestie pellentesque ultrices, nam nec maecenas varius facilisis duis non, fusce hendrerit habitasse dictum himenaeos cras nulla. Sem primis curabitur diam pretium vel etiam laoreet, sociis scelerisque mattis nascetur dis ullamcorper magna, velit ultricies auctor potenti molestie gravida. Tempus cursus augue lectus purus porta massa blandit arcu, hac ac rutrum nostra cum sagittis tristique venenatis, porttitor dictumst egestas euismod ligula aenean suscipit.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 4, 24, 11, 4, 38, 436, DateTimeKind.Local).AddTicks(1081),
                            ImageId = new Guid("4b7e17f3-1096-443d-a24f-ca83de5b740b"),
                            IsDeleted = false,
                            Title = "Asp.net Core Deneme Makalesi 1",
                            UserId = new Guid("28235d4c-8428-47b8-96c3-7ae23ebafca9"),
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("70fd2680-9625-44df-915e-1af5f25086a8"),
                            CategoryId = new Guid("e4d869d1-37a8-4b5d-9712-e9da0a2b193c"),
                            Content = "Visual studio Lorem ipsum dolor sit amet consectetur adipiscing elit posuere vivamus, potenti habitant bibendum luctus lacus mus non risus. Dis habitant est suscipit nunc iaculis non mollis mi nibh rhoncus dignissim facilisi, laoreet per id pretium vivamus bibendum sociis ultricies facilisis auctor. Etiam at eleifend montes lacinia orci molestie pellentesque ultrices, nam nec maecenas varius facilisis duis non, fusce hendrerit habitasse dictum himenaeos cras nulla. Sem primis curabitur diam pretium vel etiam laoreet, sociis scelerisque mattis nascetur dis ullamcorper magna, velit ultricies auctor potenti molestie gravida. Tempus cursus augue lectus purus porta massa blandit arcu, hac ac rutrum nostra cum sagittis tristique venenatis, porttitor dictumst egestas euismod ligula aenean suscipit.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 4, 24, 11, 4, 38, 436, DateTimeKind.Local).AddTicks(1108),
                            ImageId = new Guid("df826779-4901-4e2f-ab80-4f1ce6033ed1"),
                            IsDeleted = false,
                            Title = "Visual studio Deneme Makalesi 1",
                            UserId = new Guid("62a1399a-9802-41ea-9b25-68c523af5783"),
                            ViewCount = 15
                        });
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.ArticleVisitor", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "VisitorId");

                    b.HasIndex("VisitorId");

                    b.ToTable("ArticleVisitor");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("18c390e3-807f-4890-b74d-a3b0bd6b2364"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 4, 24, 11, 4, 38, 437, DateTimeKind.Local).AddTicks(522),
                            IsDeleted = false,
                            Name = "ASP.NET Core"
                        },
                        new
                        {
                            Id = new Guid("e4d869d1-37a8-4b5d-9712-e9da0a2b193c"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 4, 24, 11, 4, 38, 437, DateTimeKind.Local).AddTicks(540),
                            IsDeleted = false,
                            Name = "Visual studio 2022"
                        });
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b7e17f3-1096-443d-a24f-ca83de5b740b"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 4, 24, 11, 4, 38, 437, DateTimeKind.Local).AddTicks(1192),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("df826779-4901-4e2f-ab80-4f1ce6033ed1"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 4, 24, 11, 4, 38, 437, DateTimeKind.Local).AddTicks(1207),
                            FileName = "images/vstest",
                            FileType = "png",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUser", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserClaim", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserLogin", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserRole", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUserToken", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Article", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeBlog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.HasOne("YoutubeBlog.Entity.Entities.AppUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.ArticleVisitor", b =>
                {
                    b.HasOne("YoutubeBlog.Entity.Entities.Article", "Article")
                        .WithMany("ArticleVisitors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeBlog.Entity.Entities.Visitor", "Visitor")
                        .WithMany("ArticleVisitors")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Article", b =>
                {
                    b.Navigation("ArticleVisitors");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("YoutubeBlog.Entity.Entities.Visitor", b =>
                {
                    b.Navigation("ArticleVisitors");
                });
#pragma warning restore 612, 618
        }
    }
}
