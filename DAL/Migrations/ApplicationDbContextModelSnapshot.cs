﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DAL.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("DAL.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DAL.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("DAL.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("PublicatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.Property<int>("FollowingsId")
                        .HasColumnType("int");

                    b.HasKey("FollowersId", "FollowingsId");

                    b.HasIndex("FollowingsId");

                    b.ToTable("UserUser");
                });

            modelBuilder.Entity("DAL.Models.Comment", b =>
                {
                    b.HasOne("DAL.Models.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Like", b =>
                {
                    b.HasOne("DAL.Models.Post", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Post", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.HasOne("DAL.Models.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FollowingsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
