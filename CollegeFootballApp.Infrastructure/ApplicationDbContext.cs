using CollegeFootballApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollegeFootballApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamConference> TeamConferences { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining primary keys
            modelBuilder.Entity<Conference>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Game>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Team>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TeamConference>()
                .HasKey(tc => new { tc.TeamId, tc.ConferenceId });

            modelBuilder.Entity<Venue>()
                .HasKey(v => v.Id);

            // Setting up relationships

            // Game to Venue relationship
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Venue)
                .WithMany()
                .HasForeignKey(g => g.VenueId);

            // Game to TeamConference relationship
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeamConference)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamConferenceId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeamConference)
                .WithMany()
                .HasForeignKey(g => g.AwayTeamConferenceId);

            // TeamConference relationships
            modelBuilder.Entity<TeamConference>()
                .HasOne(tc => tc.Team)
                .WithMany()
                .HasForeignKey(tc => tc.TeamId);

            modelBuilder.Entity<TeamConference>()
                .HasOne(tc => tc.Conference)
                .WithMany()
                .HasForeignKey(tc => tc.ConferenceId);

            // Team to Venue relationship (Location)
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Location)
                .WithMany()
                .HasForeignKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}