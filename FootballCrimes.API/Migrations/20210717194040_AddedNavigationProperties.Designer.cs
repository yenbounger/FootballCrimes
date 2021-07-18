﻿// <auto-generated />
using System;
using FootballCrimes.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballCrimes.API.Migrations
{
    [DbContext(typeof(FootballCrimesContext))]
    [Migration("20210717194040_AddedNavigationProperties")]
    partial class AddedNavigationProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballCrimes.API.Models.Crime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StadiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Stadium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ValidatedPostcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<string>("CrestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.Property<Guid>("SeasonsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SeasonsId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("SeasonTeam");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Crime", b =>
                {
                    b.HasOne("FootballCrimes.API.Models.Stadium", "Stadium")
                        .WithMany("Crimes")
                        .HasForeignKey("StadiumId");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Stadium", b =>
                {
                    b.HasOne("FootballCrimes.API.Models.Team", "Team")
                        .WithOne("Stadium")
                        .HasForeignKey("FootballCrimes.API.Models.Stadium", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.HasOne("FootballCrimes.API.Models.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballCrimes.API.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Stadium", b =>
                {
                    b.Navigation("Crimes");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Team", b =>
                {
                    b.Navigation("Stadium");
                });
#pragma warning restore 612, 618
        }
    }
}
