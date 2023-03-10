﻿// <auto-generated />
using System;
using CompetitionService.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompetitionService.DataAccess.Migrations
{
    [DbContext(typeof(CompetitionDbContext))]
    [Migration("20230310010508_AddOutcomeType")]
    partial class AddOutcomeType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.Coefficient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<Guid>("CoefficientGroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OutcomeType")
                        .HasColumnType("integer");

                    b.Property<double>("Probability")
                        .HasColumnType("double precision");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.Property<int>("StatusType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoefficientGroupId");

                    b.ToTable("Coefficients", (string)null);
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CoefficientGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompetitionBaseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionBaseId");

                    b.ToTable("CoefficientGroups", (string)null);
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CompetitionBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusType")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CompetitionBases", (string)null);
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CompetitionDota2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompetitionBaseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Team1Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Team1KillAmount")
                        .HasColumnType("integer");

                    b.Property<Guid>("Team2Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Team2KillAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TotalTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionBaseId");

                    b.ToTable("CompetitionsDota2", (string)null);
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.Coefficient", b =>
                {
                    b.HasOne("CompetitionService.BusinessLogic.Entities.CoefficientGroup", "CoefficientGroup")
                        .WithMany("Coefficients")
                        .HasForeignKey("CoefficientGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoefficientGroup");
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CoefficientGroup", b =>
                {
                    b.HasOne("CompetitionService.BusinessLogic.Entities.CompetitionBase", "CompetitionBase")
                        .WithMany("CoefficientGroups")
                        .HasForeignKey("CompetitionBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompetitionBase");
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CompetitionDota2", b =>
                {
                    b.HasOne("CompetitionService.BusinessLogic.Entities.CompetitionBase", "CompetitionBase")
                        .WithMany()
                        .HasForeignKey("CompetitionBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompetitionBase");
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CoefficientGroup", b =>
                {
                    b.Navigation("Coefficients");
                });

            modelBuilder.Entity("CompetitionService.BusinessLogic.Entities.CompetitionBase", b =>
                {
                    b.Navigation("CoefficientGroups");
                });
#pragma warning restore 612, 618
        }
    }
}