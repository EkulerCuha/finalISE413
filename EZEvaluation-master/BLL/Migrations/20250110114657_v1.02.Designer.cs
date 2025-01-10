﻿// <auto-generated />
using System;
using BLL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BLL.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20250110114657_v1.02")]
    partial class v102
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BLL.DAL.Evaluated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Evaluateds");
                });

            modelBuilder.Entity("BLL.DAL.EvaluatedEvaluations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EvaluatedId")
                        .HasColumnType("integer");

                    b.Property<int>("EvaluationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatedId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("EvaluatedEvaluations");
                });

            modelBuilder.Entity("BLL.DAL.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal>("Score")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("BLL.DAL.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BLL.DAL.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BLL.DAL.EvaluatedEvaluations", b =>
                {
                    b.HasOne("BLL.DAL.Evaluated", "Evaluated")
                        .WithMany("EvaluatedEvaluations")
                        .HasForeignKey("EvaluatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BLL.DAL.Evaluation", "Evaluation")
                        .WithMany("EvaluatedEvaluations")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluated");

                    b.Navigation("Evaluation");
                });

            modelBuilder.Entity("BLL.DAL.Evaluation", b =>
                {
                    b.HasOne("BLL.DAL.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BLL.DAL.User", b =>
                {
                    b.HasOne("BLL.DAL.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BLL.DAL.Evaluated", b =>
                {
                    b.Navigation("EvaluatedEvaluations");
                });

            modelBuilder.Entity("BLL.DAL.Evaluation", b =>
                {
                    b.Navigation("EvaluatedEvaluations");
                });

            modelBuilder.Entity("BLL.DAL.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
