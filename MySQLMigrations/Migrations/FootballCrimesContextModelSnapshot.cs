﻿// <auto-generated />
using System;
using FootballCrimes.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MySQLMigrations.Migrations
{
    [DbContext(typeof(FootballCrimesContext))]
    partial class FootballCrimesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("FootballCrimes.API.Models.Crime", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("StadiumId")
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Season", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Stadium", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte[]>("TeamId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("ValidatedPostcode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("FootballCrimes.API.Models.Team", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<string>("CrestUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.Property<byte[]>("SeasonsId")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("TeamsId")
                        .HasColumnType("varbinary(16)");

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