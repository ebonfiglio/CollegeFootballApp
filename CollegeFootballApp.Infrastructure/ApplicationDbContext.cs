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

            // Game to TeamConference relationship for HomeTeamConference
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeamConference)
                .WithMany()
                .HasForeignKey(g => new { g.HomeTeamId, g.HomeConferenceId })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete/update

            // Game to TeamConference relationship for AwayTeamConference
            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeamConference)
                .WithMany()
                .HasForeignKey(g => new { g.AwayTeamId, g.AwayConferenceId })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete/update

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