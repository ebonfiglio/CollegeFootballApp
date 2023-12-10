﻿// <auto-generated />
using System;
using CollegeFootballApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollegeFootballApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231209184556_ScoreProps")]
    partial class ScoreProps
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.Conference", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Attendance")
                        .HasColumnType("int");

                    b.Property<string>("AwayConferenceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AwayDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwayLineScores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AwayPoints")
                        .HasColumnType("int");

                    b.Property<double?>("AwayPostWinProb")
                        .HasColumnType("float");

                    b.Property<int?>("AwayPostgameElo")
                        .HasColumnType("int");

                    b.Property<int?>("AwayPregameElo")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<bool?>("Completed")
                        .HasColumnType("bit");

                    b.Property<bool?>("ConferenceGame")
                        .HasColumnType("bit");

                    b.Property<float?>("ExcitementIndex")
                        .HasColumnType("real");

                    b.Property<string>("Highlights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeConferenceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("HomeLineScores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomePoints")
                        .HasColumnType("int");

                    b.Property<double?>("HomePostWinProb")
                        .HasColumnType("float");

                    b.Property<int?>("HomePostgameElo")
                        .HasColumnType("int");

                    b.Property<int?>("HomePregameElo")
                        .HasColumnType("int");

                    b.Property<bool?>("NeutralSite")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<string>("SeasonType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("StartTimeTbd")
                        .HasColumnType("bit");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.HasIndex("AwayTeamId", "AwayConferenceName");

                    b.HasIndex("HomeId", "HomeConferenceName");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AltColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AltName1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AltName2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AltName3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mascot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.TeamConference", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("ConferenceName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TeamId", "ConferenceName");

                    b.HasIndex("ConferenceName");

                    b.ToTable("TeamConferences");
                });

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Dome")
                        .HasColumnType("bit");

                    b.Property<float?>("Elevation")
                        .HasColumnType("real");

                    b.Property<bool?>("Grass")
                        .HasColumnType("bit");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearConstructed")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.Game", b =>
                {
                    b.HasOne("CollegeFootballApp.Domain.Entities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollegeFootballApp.Domain.Entities.TeamConference", "AwayTeamConference")
                        .WithMany()
                        .HasForeignKey("AwayTeamId", "AwayConferenceName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CollegeFootballApp.Domain.Entities.TeamConference", "HomeTeamConference")
                        .WithMany()
                        .HasForeignKey("HomeId", "HomeConferenceName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AwayTeamConference");

                    b.Navigation("HomeTeamConference");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("CollegeFootballApp.Domain.Entities.TeamConference", b =>
                {
                    b.HasOne("CollegeFootballApp.Domain.Entities.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollegeFootballApp.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
